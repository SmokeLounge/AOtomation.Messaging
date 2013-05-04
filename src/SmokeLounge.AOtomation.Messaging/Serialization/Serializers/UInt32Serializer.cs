// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UInt32Serializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the UInt32Serializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    public class UInt32Serializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public UInt32Serializer()
        {
            this.type = typeof(uint);
            this.Serializer = this.Serialize;
            this.Deserializer = this.Deserialize;
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationOptions, object> Deserializer { get; private set; }

        public Action<StreamWriter, SerializationOptions, object> Serializer { get; private set; }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            var readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<uint>>(o => o.ReadUInt32);
            var callReadExp = Expression.Call(streamReaderExpression, readMethodInfo);
            if (assignmentTargetExpression.Type.IsAssignableFrom(this.type))
            {
                return Expression.Assign(assignmentTargetExpression, callReadExp);
            }

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.Convert(callReadExp, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            var writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<uint>>(o => o.WriteUInt32);
            if (valueExpression.Type.IsAssignableFrom(this.type))
            {
                return Expression.Call(streamWriterExpression, writeMethodInfo, new[] { valueExpression });
            }

            var callWriteExp = Expression.Call(
                streamWriterExpression, 
                writeMethodInfo, 
                new Expression[] { Expression.Convert(valueExpression, this.type) });
            return callWriteExp;
        }

        #endregion

        #region Methods

        private object Deserialize(StreamReader reader, SerializationOptions options)
        {
            return reader.ReadUInt32();
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object o)
        {
            writer.WriteUInt32((uint)o);
        }

        #endregion
    }
}