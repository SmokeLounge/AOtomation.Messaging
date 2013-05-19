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
            var debugInfoExpression = Expression.Variable(typeof(DebugInfo));
            var debugInfoAssignmentExpression = Expression.Assign(
                debugInfoExpression, Expression.New(typeof(DebugInfo)));

            var propertyMetaDataPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.PropertyMetaData);
            var assignPropertyMetaDataExpression =
                Expression.Assign(
                    Expression.Property(debugInfoExpression, propertyMetaDataPropertyInfo), 
                    Expression.Constant(propertyMetaData, typeof(PropertyMetaData)));

            var addDebugInfoMethodInfo =
                ReflectionHelper.GetMethodInfo<SerializationContext, Action<DebugInfo>>(o => o.AddDebugInfo);
            var callAddDebugInfoExpression = Expression.Call(
                serializationContextExpression, addDebugInfoMethodInfo, new Expression[] { debugInfoExpression });

            var offsetPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Offset);
            var positionPropertyInfo = ReflectionHelper.GetPropertyInfo<StreamReader>(o => o.Position);
            var assignOffsetExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, offsetPropertyInfo), 
                Expression.Property(streamReaderExpression, positionPropertyInfo));

            var deserializerExpression = this.serializer.DeserializerExpression(
                streamReaderExpression, serializationContextExpression, assignmentTargetExpression, propertyMetaData);

            var lengthPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Length);
            var calculateLengthExpression =
                Expression.Subtract(
                    Expression.Property(streamReaderExpression, positionPropertyInfo), 
                    Expression.Property(debugInfoExpression, offsetPropertyInfo));
            var assignLengthExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, lengthPropertyInfo), calculateLengthExpression);

            var valuePropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Value);
            var assignValueExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, valuePropertyInfo), 
                Expression.Convert(assignmentTargetExpression, typeof(object)));

            var blockExpression = Expression.Block(
                new[] { debugInfoExpression }, 
                new[]
                    {
                        debugInfoAssignmentExpression, assignPropertyMetaDataExpression, callAddDebugInfoExpression, 
                        assignOffsetExpression, deserializerExpression, assignLengthExpression, assignValueExpression
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
            var debugInfoExpression = Expression.Variable(typeof(DebugInfo));
            var debugInfoAssignmentExpression = Expression.Assign(
                debugInfoExpression, Expression.New(typeof(DebugInfo)));

            var propertyMetaDataPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.PropertyMetaData);
            var assignPropertyMetaDataExpression =
                Expression.Assign(
                    Expression.Property(debugInfoExpression, propertyMetaDataPropertyInfo), 
                    Expression.Constant(propertyMetaData, typeof(PropertyMetaData)));

            var addDebugInfoMethodInfo =
                ReflectionHelper.GetMethodInfo<SerializationContext, Action<DebugInfo>>(o => o.AddDebugInfo);
            var callAddDebugInfoExpression = Expression.Call(
                serializationContextExpression, addDebugInfoMethodInfo, new Expression[] { debugInfoExpression });

            var offsetPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Offset);
            var positionPropertyInfo = ReflectionHelper.GetPropertyInfo<StreamWriter>(o => o.Position);
            var assignOffsetExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, offsetPropertyInfo), 
                Expression.Property(streamWriterExpression, positionPropertyInfo));

            var serializerExpression = this.serializer.SerializerExpression(
                streamWriterExpression, serializationContextExpression, valueExpression, propertyMetaData);

            var lengthPropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Length);
            var calculateLengthExpression =
                Expression.Subtract(
                    Expression.Property(streamWriterExpression, positionPropertyInfo), 
                    Expression.Property(debugInfoExpression, offsetPropertyInfo));
            var assignLengthExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, lengthPropertyInfo), calculateLengthExpression);

            var valuePropertyInfo = ReflectionHelper.GetPropertyInfo<DebugInfo>(o => o.Value);
            var assignValueExpression = Expression.Assign(
                Expression.Property(debugInfoExpression, valuePropertyInfo), 
                Expression.Convert(valueExpression, typeof(object)));

            var blockExpression = Expression.Block(
                new[] { debugInfoExpression }, 
                new[]
                    {
                        debugInfoAssignmentExpression, assignPropertyMetaDataExpression, callAddDebugInfoExpression, 
                        assignOffsetExpression, serializerExpression, assignLengthExpression, assignValueExpression
                    });
            return blockExpression;
        }

        #endregion
    }
}