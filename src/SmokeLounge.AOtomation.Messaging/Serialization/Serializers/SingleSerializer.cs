// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SingleSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    public class SingleSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public SingleSerializer()
        {
            this.type = typeof(float);
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
            var readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<float>>(o => o.ReadSingle);
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
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            var writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<float>>(o => o.WriteSingle);
            if (valueExpression.Type.IsAssignableFrom(this.type))
            {
                return Expression.Call(streamWriterExpression, writeMethodInfo, new[] { valueExpression });
            }

            var callWriteExp = Expression.Call(
                streamWriterExpression, writeMethodInfo, new[] { Expression.Convert(valueExpression, this.type) });
            return callWriteExp;
        }

        #endregion

        #region Methods

        private object Deserialize(StreamReader reader, SerializationOptions options)
        {
            return reader.ReadSingle();
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object o)
        {
            writer.WriteSingle((short)o);
        }

        #endregion
    }
}