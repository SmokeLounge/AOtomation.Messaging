// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DiagnosticSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    public class DiagnosticSerializer : ISerializer
    {
        #region Fields

        private readonly ISerializer serializer;

        #endregion

        #region Constructors and Destructors

        public DiagnosticSerializer(ISerializer serializer)
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
            var beginMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <DiagnosticSerializer, Func<StreamReader, SerializationContext, PropertyMetaData, Probe>>(
                        o => o.BeginProbeDeserialize);
            var callBeginExpression = Expression.Call(
                Expression.Constant(this), 
                beginMethodInfo, 
                new Expression[]
                    {
                       streamReaderExpression, serializationContextExpression, Expression.Constant(propertyMetaData) 
                    });

            var probeExpression = Expression.Variable(typeof(Probe));
            var assignProbeExpression = Expression.Assign(probeExpression, callBeginExpression);

            var deserializerExpression = this.serializer.DeserializerExpression(
                streamReaderExpression, serializationContextExpression, assignmentTargetExpression, propertyMetaData);

            var endMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <DiagnosticSerializer, Action<StreamReader, SerializationContext, PropertyMetaData, object, Probe>>(
                        o => o.EndProbeDeserialize);
            var callEndExpression = Expression.Call(
                Expression.Constant(this), 
                endMethodInfo, 
                new Expression[]
                    {
                        streamReaderExpression, serializationContextExpression, Expression.Constant(propertyMetaData), 
                        Expression.Convert(assignmentTargetExpression, typeof(object)), probeExpression
                    });

            var tryFinallyExpression =
                Expression.TryFinally(
                    Expression.Block(assignProbeExpression, deserializerExpression), callEndExpression);

            var block = Expression.Block(new[] { probeExpression }, new[] { tryFinallyExpression });

            return block;
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
            var beginMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <DiagnosticSerializer, Func<StreamWriter, SerializationContext, object, PropertyMetaData, Probe>>(
                        o => o.BeginProbeSerialize);
            var callBeginExpression = Expression.Call(
                Expression.Constant(this), 
                beginMethodInfo, 
                new Expression[]
                    {
                        streamWriterExpression, serializationContextExpression, 
                        Expression.Convert(valueExpression, typeof(object)), Expression.Constant(propertyMetaData)
                    });

            var probeExpression = Expression.Variable(typeof(Probe));
            var assignProbeExpression = Expression.Assign(probeExpression, callBeginExpression);

            var serializerExpression = this.serializer.SerializerExpression(
                streamWriterExpression, serializationContextExpression, valueExpression, propertyMetaData);

            var endMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <DiagnosticSerializer, Action<StreamWriter, SerializationContext, object, PropertyMetaData, Probe>>(
                        o => o.EndProbeSerialize);
            var callEndExpression = Expression.Call(
                Expression.Constant(this), 
                endMethodInfo, 
                new Expression[]
                    {
                        streamWriterExpression, serializationContextExpression, 
                        Expression.Convert(valueExpression, typeof(object)), Expression.Constant(propertyMetaData), 
                        probeExpression
                    });

            var tryFinallyExpression =
                Expression.TryFinally(Expression.Block(assignProbeExpression, serializerExpression), callEndExpression);

            var block = Expression.Block(new[] { probeExpression }, new[] { tryFinallyExpression });

            return block;
        }

        #endregion

        #region Methods

        private Probe BeginProbeDeserialize(
            StreamReader streamReader, SerializationContext serializationContext, PropertyMetaData propertyMetaData)
        {
            var probe = serializationContext.BeginProbe();
            probe.DiagnosticInfo.Offset = streamReader.Position;
            probe.DiagnosticInfo.PropertyMetaData = propertyMetaData;
            return probe;
        }

        private Probe BeginProbeSerialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            PropertyMetaData propertyMetaData)
        {
            var probe = serializationContext.BeginProbe();
            probe.DiagnosticInfo.Offset = streamWriter.Position;
            probe.DiagnosticInfo.PropertyMetaData = propertyMetaData;
            probe.DiagnosticInfo.Value = value;
            return probe;
        }

        private void EndProbeDeserialize(
            StreamReader streamReader, 
            SerializationContext serializationContext, 
            PropertyMetaData propertyMetaData, 
            object deserializedObject, 
            Probe probe)
        {
            probe.DiagnosticInfo.Length = streamReader.Position - probe.DiagnosticInfo.Offset;
            probe.DiagnosticInfo.Value = deserializedObject;
            serializationContext.EndProbe(probe);
        }

        private void EndProbeSerialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            PropertyMetaData propertyMetaData, 
            Probe probe)
        {
            probe.DiagnosticInfo.Length = streamWriter.Position - probe.DiagnosticInfo.Offset;
            serializationContext.EndProbe(probe);
        }

        #endregion
    }
}