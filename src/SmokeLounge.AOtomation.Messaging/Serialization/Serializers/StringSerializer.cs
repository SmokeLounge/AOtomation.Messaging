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
            ConstantExpression optionsExpression, 
            Expression assignmentTargetExpression)
        {
            var expressions = new List<Expression>();

            var size = Expression.Variable(typeof(int), "size");

            Expression setSize;

            var options = (SerializationOptions)optionsExpression.Value;

            if (options.SerializeSize == ArraySizeType.NoSerialization)
            {
                setSize = Expression.Assign(size, Expression.Constant(options.FixedSizeLength, typeof(int)));
            }
            else
            {
                setSize = new ArraySizeSerializer(options.SerializeSize).DeserializerExpression(
                    streamReaderExpression, optionsExpression, size);
            }

            expressions.Add(setSize);

            var readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<int, string>>(o => o.ReadString);
            var callReadExp = Expression.Call(streamReaderExpression, readMethodInfo, new Expression[] { size });

            Expression setString = assignmentTargetExpression.Type.IsAssignableFrom(this.type)
                                       ? Expression.Assign(assignmentTargetExpression, callReadExp)
                                       : Expression.Assign(
                                           assignmentTargetExpression, 
                                           Expression.Convert(callReadExp, assignmentTargetExpression.Type));

            expressions.Add(setString);

            var block = Expression.Block(new[] { size }, expressions);
            return block;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            if (valueExpression.Type.IsAssignableFrom(this.type) == false)
            {
                valueExpression = Expression.Convert(valueExpression, this.type);
            }

            var options = (SerializationOptions)optionsExpression.Value;

            var expressions = new List<Expression>();
            if (options.SerializeSize != ArraySizeType.NoSerialization)
            {
                var serializeSizeExp =
                    new ArraySizeSerializer(options.SerializeSize).SerializerExpression(
                        streamWriterExpression, optionsExpression, valueExpression);
                expressions.Add(serializeSizeExp);
            }

            var writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<string, int?>>(o => o.WriteString);

            Expression writeStringParam = options.IsFixedSize
                                              ? Expression.Constant(options.FixedSizeLength, typeof(int?))
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

        #region Methods

        private object Deserialize(StreamReader reader, SerializationOptions options)
        {
            throw new NotImplementedException();
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}