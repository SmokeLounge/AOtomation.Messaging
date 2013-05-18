// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StringSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class StringSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public StringSerializer()
        {
            this.type = typeof(string);
        }

        #endregion

        #region Public Properties

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
            StreamReader streamReader, 
            SerializationContext serializationContext, 
            PropertyMetaData propertyMetaData = null)
        {
            int length;
            if (propertyMetaData.Options.SerializeSize == ArraySizeType.NoSerialization)
            {
                length = propertyMetaData.Options.FixedSizeLength;
            }
            else
            {
                var arraySizeSerializer = new ArraySizeSerializer(propertyMetaData.Options.SerializeSize);
                length =
                    (int)
                    arraySizeSerializer.Deserialize(
                        streamReader, serializationContext, propertyMetaData: propertyMetaData);
            }

            return streamReader.ReadString(length);
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression serializationContextExpression, 
            Expression assignmentTargetExpression, 
            PropertyMetaData propertyMetaData)
        {
            var expressions = new List<Expression>();

            var lengthExpression = Expression.Variable(typeof(int), "length");

            Expression assignLengthExpression;

            if (propertyMetaData.Options.SerializeSize == ArraySizeType.NoSerialization)
            {
                assignLengthExpression = Expression.Assign(
                    lengthExpression, Expression.Constant(propertyMetaData.Options.FixedSizeLength, typeof(int)));
            }
            else
            {
                assignLengthExpression =
                    new ArraySizeSerializer(propertyMetaData.Options.SerializeSize).DeserializerExpression(
                        streamReaderExpression, serializationContextExpression, lengthExpression, propertyMetaData);
            }

            expressions.Add(assignLengthExpression);

            var readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<int, string>>(o => o.ReadString);
            var callReadExp = Expression.Call(
                streamReaderExpression, readMethodInfo, new Expression[] { lengthExpression });

            Expression setString = assignmentTargetExpression.Type.IsAssignableFrom(this.type)
                                       ? Expression.Assign(assignmentTargetExpression, callReadExp)
                                       : Expression.Assign(
                                           assignmentTargetExpression, 
                                           Expression.Convert(callReadExp, assignmentTargetExpression.Type));

            expressions.Add(setString);

            var block = Expression.Block(new[] { lengthExpression }, expressions);
            return block;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            PropertyMetaData propertyMetaData = null)
        {
            if (propertyMetaData.Options.SerializeSize != ArraySizeType.NoSerialization)
            {
                var arraySizeSerializer = new ArraySizeSerializer(propertyMetaData.Options.SerializeSize);
                arraySizeSerializer.Serialize(streamWriter, serializationContext, value, propertyMetaData);
            }

            var writeStringParam = propertyMetaData.Options.IsFixedSize
                                       ? (int?)propertyMetaData.Options.FixedSizeLength
                                       : null;
            streamWriter.WriteString((string)value, writeStringParam);
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression serializationContextExpression, 
            Expression valueExpression, 
            PropertyMetaData propertyMetaData)
        {
            if (valueExpression.Type.IsAssignableFrom(this.type) == false)
            {
                valueExpression = Expression.Convert(valueExpression, this.type);
            }

            var expressions = new List<Expression>();
            if (propertyMetaData.Options.SerializeSize != ArraySizeType.NoSerialization)
            {
                var serializeSizeExp =
                    new ArraySizeSerializer(propertyMetaData.Options.SerializeSize).SerializerExpression(
                        streamWriterExpression, serializationContextExpression, valueExpression, propertyMetaData);
                expressions.Add(serializeSizeExp);
            }

            var writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<string, int?>>(o => o.WriteString);

            Expression writeStringParam = propertyMetaData.Options.IsFixedSize
                                              ? Expression.Constant(
                                                  propertyMetaData.Options.FixedSizeLength, typeof(int?))
                                              : Expression.Constant(null, typeof(int?));

            var callWriteExp = Expression.Call(
                streamWriterExpression, 
                writeMethodInfo, 
                new[] { Expression.Convert(valueExpression, this.type), writeStringParam });
            expressions.Add(callWriteExp);
            var block = Expression.Block(expressions);
            return block;
        }

        #endregion
    }
}