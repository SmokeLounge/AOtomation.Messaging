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
            int arrayLength;
            if (propertyMetaData.Options.SerializeSize != ArraySizeType.NoSerialization)
            {
                var arraySizeSerializer = new ArraySizeSerializer(propertyMetaData.Options.SerializeSize);
                arrayLength = (int)arraySizeSerializer.Deserialize(streamReader, serializationContext, propertyMetaData);
            }
            else
            {
                arrayLength = propertyMetaData.Options.FixedSizeLength;
            }

            var array = Array.CreateInstance(this.typeSerializer.Type, arrayLength);
            for (var i = 0; i < arrayLength; i++)
            {
                var element = this.typeSerializer.Deserialize(streamReader, serializationContext, propertyMetaData);
                array.SetValue(element, i);
            }

            return array;
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression serializationContextExpression, 
            Expression assignmentTargetExpression, 
            PropertyMetaData propertyMetaData)
        {
            var expressions = new List<Expression>();

            var arrayLength = Expression.Variable(typeof(int), "size");

            Expression setArrayLength;
            if (propertyMetaData.Options.SerializeSize != ArraySizeType.NoSerialization)
            {
                setArrayLength =
                    new ArraySizeSerializer(propertyMetaData.Options.SerializeSize).DeserializerExpression(
                        streamReaderExpression, serializationContextExpression, arrayLength, propertyMetaData);
            }
            else
            {
                setArrayLength = Expression.Assign(
                    arrayLength, Expression.Constant(propertyMetaData.Options.FixedSizeLength, typeof(int)));
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
                                streamReaderExpression, serializationContextExpression, element, propertyMetaData), 
                            assign, Expression.Assign(counter, Expression.Increment(counter))
                        }), 
                Expression.Break(@break));

            var forExp = Expression.Loop(ifElse, @break);
            expressions.Add(forExp);

            var assignExp = Expression.Assign(assignmentTargetExpression, Expression.Convert(newArray, this.type));
            expressions.Add(assignExp);

            var block = Expression.Block(new[] { arrayLength, newArray, counter }, expressions);
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
                arraySizeSerializer.Serialize(
                    streamWriter, serializationContext, value, propertyMetaData: propertyMetaData);
            }

            var array = (Array)value;
            for (var i = 0; i < array.Length; i++)
            {
                this.typeSerializer.Serialize(
                    streamWriter, serializationContext, array.GetValue(i), propertyMetaData: propertyMetaData);
            }
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
                                streamWriterExpression, serializationContextExpression, element, propertyMetaData), 
                            Expression.Assign(counter, Expression.Increment(counter))
                        }), 
                Expression.Break(@break));

            var forExp = Expression.Loop(ifElse, @break);
            expressions.Add(forExp);

            var block = Expression.Block(new[] { counter }, expressions);
            return block;
        }

        #endregion
    }
}