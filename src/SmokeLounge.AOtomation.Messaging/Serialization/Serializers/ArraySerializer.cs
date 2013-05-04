// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArraySerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ArraySerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class ArraySerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        private readonly ISerializer typeSerializer;

        #endregion

        #region Constructors and Destructors

        public ArraySerializer(Type type, ISerializer typeSerializer)
        {
            this.type = type;
            this.typeSerializer = typeSerializer;
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
            var expressions = new List<Expression>();

            var arrayLength = Expression.Variable(typeof(int), "size");

            Expression setArrayLength;
            if (memberOptions.SerializeSize != ArraySizeType.NoSerialization)
            {
                setArrayLength =
                    new ArraySizeSerializer(memberOptions.SerializeSize).DeserializerExpression(
                        streamReaderExpression, optionsExpression, arrayLength, memberOptions);
            }
            else
            {
                setArrayLength = Expression.Assign(
                    arrayLength, Expression.Constant(memberOptions.FixedSizeLength, typeof(int)));
            }

            expressions.Add(setArrayLength);

            var createNewArray = Expression.NewArrayBounds(this.typeSerializer.Type, arrayLength);
            var newArray = Expression.Parameter(this.type, "newArray");
            expressions.Add(Expression.Assign(newArray, createNewArray));

            var @break = Expression.Label();
            var counter = Expression.Variable(typeof(int), "i");
            expressions.Add(Expression.Assign(counter, Expression.Constant(0)));
            var element = Expression.Variable(this.typeSerializer.Type, "element");
            var assign = Expression.Assign(Expression.ArrayAccess(newArray, counter), element);
            var ifElse = Expression.IfThenElse(
                Expression.LessThan(counter, arrayLength), 
                Expression.Block(
                    new[] { element }, 
                    new[]
                        {
                            this.typeSerializer.DeserializerExpression(
                                streamReaderExpression, optionsExpression, element, memberOptions), 
                            assign, 
                            Expression.Assign(counter, Expression.Increment(counter))
                        }), 
                Expression.Break(@break));

            var forExp = Expression.Loop(ifElse, @break);
            expressions.Add(forExp);

            var assignExp = Expression.Assign(assignmentTargetExpression, Expression.Convert(newArray, this.type));
            expressions.Add(assignExp);

            var block = Expression.Block(new[] { arrayLength, newArray, counter }, expressions);
            return block;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            if (valueExpression.Type.IsAssignableFrom(this.type) == false)
            {
                valueExpression = Expression.Convert(valueExpression, this.type);
            }

            var expressions = new List<Expression>();
            if (memberOptions.SerializeSize != ArraySizeType.NoSerialization)
            {
                var serializeSizeExp =
                    new ArraySizeSerializer(memberOptions.SerializeSize).SerializerExpression(
                        streamWriterExpression, optionsExpression, valueExpression, memberOptions);
                expressions.Add(serializeSizeExp);
            }

            var @break = Expression.Label();
            var arrayLength = Expression.ArrayLength(valueExpression);
            var counter = Expression.Variable(typeof(int), "i");
            expressions.Add(Expression.Assign(counter, Expression.Constant(0)));
            var element = Expression.Variable(this.typeSerializer.Type, "element");
            var assign = Expression.Assign(element, Expression.ArrayIndex(valueExpression, counter));
            var ifElse = Expression.IfThenElse(
                Expression.LessThan(counter, arrayLength), 
                Expression.Block(
                    new[] { element }, 
                    new[]
                        {
                            assign, 
                            this.typeSerializer.SerializerExpression(
                                streamWriterExpression, optionsExpression, element, memberOptions), 
                            Expression.Assign(counter, Expression.Increment(counter))
                        }), 
                Expression.Break(@break));

            var forExp = Expression.Loop(ifElse, @break);
            expressions.Add(forExp);

            var block = Expression.Block(new[] { counter }, expressions);
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