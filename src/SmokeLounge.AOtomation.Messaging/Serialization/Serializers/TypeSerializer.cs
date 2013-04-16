// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TypeSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    public class TypeSerializer : ISerializer
    {
        #region Fields

        private readonly Lazy<Func<StreamReader, SerializationOptions, object>> deserializer;

        private readonly Expression deserializerExpression;

        private readonly Lazy<Action<StreamWriter, SerializationOptions, object>> serializer;

        private readonly Expression serializerExpression;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public TypeSerializer(Type type, Expression serializerExpression, Expression deserializerExpression)
        {
            this.type = type;
            this.serializerExpression = serializerExpression;
            this.deserializerExpression = deserializerExpression;
            this.serializer = new Lazy<Action<StreamWriter, SerializationOptions, object>>(this.CompileSerializer);
            this.deserializer = new Lazy<Func<StreamReader, SerializationOptions, object>>(this.CompileDeserializer);
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationOptions, object> Deserializer
        {
            get
            {
                return this.deserializer.Value;
            }
        }

        public Action<StreamWriter, SerializationOptions, object> Serializer
        {
            get
            {
                return this.serializer.Value;
            }
        }

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
            var invokeExp = Expression.Invoke(
                this.deserializerExpression, new Expression[] { streamReaderExpression, optionsExpression });
            var assignExp = Expression.Assign(assignmentTargetExpression, Expression.Convert(invokeExp, this.type));
            return assignExp;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            var invokeExp = Expression.Invoke(
                this.serializerExpression, new[] { streamWriterExpression, optionsExpression, valueExpression });
            return invokeExp;
        }

        #endregion

        #region Methods

        private Func<StreamReader, SerializationOptions, object> CompileDeserializer()
        {
            var lambda = (Expression<Func<StreamReader, SerializationOptions, object>>)this.deserializerExpression;
            var compiledLambda = lambda.Compile();
            return compiledLambda;
        }

        private Action<StreamWriter, SerializationOptions, object> CompileSerializer()
        {
            var lambda = (Expression<Action<StreamWriter, SerializationOptions, object>>)this.serializerExpression;
            var compiledLambda = lambda.Compile();
            return compiledLambda;
        }

        #endregion
    }
}