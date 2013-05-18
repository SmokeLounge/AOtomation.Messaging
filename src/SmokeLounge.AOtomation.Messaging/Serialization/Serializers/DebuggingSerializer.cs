// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebuggingSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DebuggingSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    public class DebuggingSerializer : ISerializer
    {
        #region Fields

        private readonly ISerializer serializer;

        #endregion

        #region Constructors and Destructors

        public DebuggingSerializer(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        #endregion

        #region Public Properties

        public Type Type
        {
            get
            {
                return this.serializer.Type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public object Deserialize(
            StreamReader streamReader, 
            SerializationContext serializationContext, 
            PropertyMetaData propertyMetaData = null)
        {
            return this.serializer.Deserialize(streamReader, serializationContext, propertyMetaData);
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression serializationContextExpression, 
            Expression assignmentTargetExpression, 
            PropertyMetaData propertyMetaData)
        {
            var offsetExpression = Expression.Variable(typeof(long));
            var lengthExpression = Expression.Variable(typeof(long));
            var propertyExpression = Expression.Constant(propertyMetaData, typeof(PropertyMetaData));

            var positionPropertyInfo = ReflectionHelper.GetPropertyInfo<StreamReader>(o => o.Position);
            var assignOffsetExpression = Expression.Assign(
                offsetExpression, Expression.Property(streamReaderExpression, positionPropertyInfo));

            var serializerExpression = this.serializer.DeserializerExpression(
                streamReaderExpression, serializationContextExpression, assignmentTargetExpression, propertyMetaData);

            var subrtactExpression =
                Expression.Subtract(Expression.Property(streamReaderExpression, positionPropertyInfo), offsetExpression);
            var assignLengthExpression = Expression.Assign(lengthExpression, subrtactExpression);

            var addDebugInfoMethodInfo =
                ReflectionHelper.GetMethodInfo<SerializationContext, Action<PropertyMetaData, long, long>>(
                    o => o.AddDebugInfo);
            var callAddDebugInfoExpression = Expression.Call(
                serializationContextExpression, 
                addDebugInfoMethodInfo, 
                new Expression[] { propertyExpression, offsetExpression, lengthExpression });

            var blockExpression = Expression.Block(
                new[] { offsetExpression, lengthExpression }, 
                new[]
                    {
                       assignOffsetExpression, serializerExpression, assignLengthExpression, callAddDebugInfoExpression 
                    });

            return blockExpression;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            PropertyMetaData propertyMetaData = null)
        {
            this.serializer.Serialize(streamWriter, serializationContext, value, propertyMetaData);
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression serializationContextExpression, 
            Expression valueExpression, 
            PropertyMetaData propertyMetaData)
        {
            var offsetExpression = Expression.Variable(typeof(long));
            var lengthExpression = Expression.Variable(typeof(long));
            var propertyExpression = Expression.Constant(propertyMetaData, typeof(PropertyMetaData));

            var positionPropertyInfo = ReflectionHelper.GetPropertyInfo<StreamWriter>(o => o.Position);
            var assignOffsetExpression = Expression.Assign(
                offsetExpression, Expression.Property(streamWriterExpression, positionPropertyInfo));

            var serializerExpression = this.serializer.SerializerExpression(
                streamWriterExpression, serializationContextExpression, valueExpression, propertyMetaData);

            var subrtactExpression =
                Expression.Subtract(Expression.Property(streamWriterExpression, positionPropertyInfo), offsetExpression);
            var assignLengthExpression = Expression.Assign(lengthExpression, subrtactExpression);

            var addDebugInfoMethodInfo =
                ReflectionHelper.GetMethodInfo<SerializationContext, Action<PropertyMetaData, long, long>>(
                    o => o.AddDebugInfo);
            var callAddDebugInfoExpression = Expression.Call(
                serializationContextExpression, 
                addDebugInfoMethodInfo, 
                new Expression[] { propertyExpression, offsetExpression, lengthExpression });

            var blockExpression = Expression.Block(
                new[] { offsetExpression, lengthExpression }, 
                new[]
                    {
                       assignOffsetExpression, serializerExpression, assignLengthExpression, callAddDebugInfoExpression 
                    });

            return blockExpression;
        }

        #endregion
    }
}