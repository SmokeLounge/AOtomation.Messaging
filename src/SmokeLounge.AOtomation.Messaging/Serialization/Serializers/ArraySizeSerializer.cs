// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArraySizeSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ArraySizeSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ArraySizeSerializer : ISerializer
    {
        #region Fields

        private readonly ArraySizeType arraySizeType;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public ArraySizeSerializer(ArraySizeType arraySizeType)
        {
            this.arraySizeType = arraySizeType;
            switch (this.arraySizeType)
            {
                case ArraySizeType.Byte:
                    this.type = typeof(byte);
                    break;
                case ArraySizeType.Int16:
                    this.type = typeof(short);
                    break;
                case ArraySizeType.Int32:
                    this.type = typeof(int);
                    break;
                case ArraySizeType.X3F1:
                    this.type = typeof(int);
                    break;
            }

            this.SerializerLambda =
                (streamWriter, serializationContext, value) =>
                this.Serialize(streamWriter, serializationContext, value, null);
            this.DeserializerLambda =
                (streamReader, serializationContext) => this.Deserialize(streamReader, serializationContext, null);
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationContext, object> DeserializerLambda { get; private set; }

        public Action<StreamWriter, SerializationContext, object> SerializerLambda { get; private set; }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public object Deserialize(
            StreamReader streamReader, SerializationContext serializationContext, MemberOptions memberOptions)
        {
            switch (this.arraySizeType)
            {
                case ArraySizeType.NoSerialization:
                    return null;
                case ArraySizeType.Byte:
                    return (int)streamReader.ReadByte();
                case ArraySizeType.Int16:
                    return (int)streamReader.ReadInt16();
                case ArraySizeType.Int32:
                    return streamReader.ReadInt32();
                case ArraySizeType.X3F1:
                    var length3F1 = streamReader.ReadInt32();
                    return (length3F1 / 0x03F1) - 1;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            if (this.arraySizeType == ArraySizeType.NoSerialization)
            {
                return null;
            }

            MethodInfo readMethodInfo = null;

            if (this.type == typeof(byte))
            {
                readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<byte>>(o => o.ReadByte);
            }

            if (this.type == typeof(short))
            {
                readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<short>>(o => o.ReadInt16);
            }

            if (this.type == typeof(int))
            {
                readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<int>>(o => o.ReadInt32);
            }

            if (readMethodInfo == null)
            {
                return null;
            }

            Expression deserializedValueExpression;

            if (memberOptions.IsFixedSize)
            {
                deserializedValueExpression = Expression.Constant(memberOptions.FixedSizeLength, this.type);
            }
            else
            {
                deserializedValueExpression = Expression.Call(streamReaderExpression, readMethodInfo);
            }

            if (this.arraySizeType == ArraySizeType.X3F1)
            {
                var originalValue = deserializedValueExpression;
                deserializedValueExpression =
                    Expression.Subtract(
                        Expression.Divide(originalValue, Expression.Constant(0x03F1)), Expression.Constant(1));
            }

            var deserializerExpression = Expression.Assign(
                assignmentTargetExpression, 
                this.type == assignmentTargetExpression.Type
                    ? deserializedValueExpression
                    : Expression.Convert(deserializedValueExpression, assignmentTargetExpression.Type));

            return deserializerExpression;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            MemberOptions memberOptions)
        {
            if (this.arraySizeType == ArraySizeType.NoSerialization)
            {
                return;
            }

            var array = value as Array;
            var length = array != null ? array.Length : ((string)value).Length;

            switch (this.arraySizeType)
            {
                case ArraySizeType.NoSerialization:
                    break;
                case ArraySizeType.Byte:
                    streamWriter.WriteByte((byte)length);
                    break;
                case ArraySizeType.Int16:
                    streamWriter.WriteInt16((short)length);
                    break;
                case ArraySizeType.Int32:
                    streamWriter.WriteInt32(length);
                    break;
                case ArraySizeType.X3F1:
                    streamWriter.WriteInt32((length + 1) * 0x03F1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            if (this.arraySizeType == ArraySizeType.NoSerialization)
            {
                return null;
            }

            MethodInfo writeMethodInfo = null;

            if (this.type == typeof(byte))
            {
                writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<byte>>(o => o.WriteByte);
            }

            if (this.type == typeof(short))
            {
                writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<short>>(o => o.WriteInt16);
            }

            if (this.type == typeof(int))
            {
                writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<int>>(o => o.WriteInt32);
            }

            if (writeMethodInfo == null)
            {
                return null;
            }

            Expression serializedValueExpression;

            if (memberOptions.IsFixedSize)
            {
                serializedValueExpression = Expression.Constant(memberOptions.FixedSizeLength, this.type);
            }
            else
            {
                serializedValueExpression = Expression.Convert(
                    Expression.Property(valueExpression, "Length"), this.type);
            }

            if (this.arraySizeType == ArraySizeType.X3F1)
            {
                var originalValue = serializedValueExpression;
                serializedValueExpression = Expression.Multiply(
                    Expression.Add(originalValue, Expression.Constant(1)), Expression.Constant(0x03F1));
            }

            var serializerExpression = Expression.Call(
                streamWriterExpression, writeMethodInfo, new[] { serializedValueExpression });
            return serializerExpression;
        }

        #endregion
    }
}