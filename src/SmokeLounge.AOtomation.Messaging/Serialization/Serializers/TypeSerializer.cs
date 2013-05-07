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

        private readonly Lazy<Expression> deserializerExpression;

        private readonly Lazy<Func<StreamReader, SerializationContext, object>> lazyDeserializerLambda;

        private readonly Lazy<Action<StreamWriter, SerializationContext, object>> lazySerializerLambda;

        private readonly Lazy<Expression> serializerExpression;

        private readonly Type type;

        private readonly TypeSerializerBuilder typeSerializerBuilder;

        #endregion

        #region Constructors and Destructors

        public TypeSerializer(Type type, TypeSerializerBuilder typeSerializerBuilder)
        {
            this.type = type;
            this.typeSerializerBuilder = typeSerializerBuilder;
            this.serializerExpression = new Lazy<Expression>(this.BuildSerializerExpression);
            this.lazySerializerLambda =
                new Lazy<Action<StreamWriter, SerializationContext, object>>(this.CompileSerializer);
            this.deserializerExpression = new Lazy<Expression>(this.BuildDeserializerExpression);
            this.lazyDeserializerLambda =
                new Lazy<Func<StreamReader, SerializationContext, object>>(this.CompileDeserializer);
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

        #region Properties

        private Func<StreamReader, SerializationContext, object> DeserializerLambda
        {
            get
            {
                return this.lazyDeserializerLambda.Value;
            }
        }

        private Action<StreamWriter, SerializationContext, object> SerializerLambda
        {
            get
            {
                return this.lazySerializerLambda.Value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public object Deserialize(
            StreamReader streamReader, SerializationContext serializationContext, MemberOptions memberOptions)
        {
            return this.DeserializerLambda(streamReader, serializationContext);
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            var invokeExp = Expression.Invoke(
                this.deserializerExpression.Value, new Expression[] { streamReaderExpression, optionsExpression });
            var assignExp = Expression.Assign(assignmentTargetExpression, Expression.Convert(invokeExp, this.type));
            return assignExp;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            MemberOptions memberOptions)
        {
            this.SerializerLambda(streamWriter, serializationContext, value);
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            var invokeExp = Expression.Invoke(
                this.serializerExpression.Value, new[] { streamWriterExpression, optionsExpression, valueExpression });
            return invokeExp;
        }

        #endregion

        #region Methods

        private Expression BuildDeserializerExpression()
        {
            var readerParam = Expression.Parameter(typeof(StreamReader), "streamReader");
            var optionsParam = Expression.Parameter(typeof(SerializationContext), "serializationContext");

            var expression = this.typeSerializerBuilder.BuildDeserializer(readerParam, optionsParam);
            return expression;
        }

        private Expression BuildSerializerExpression()
        {
            var writerParam = Expression.Parameter(typeof(StreamWriter), "streamWriter");
            var optionsParam = Expression.Parameter(typeof(SerializationContext), "serializationContext");

            var expression = this.typeSerializerBuilder.BuildSerializer(writerParam, optionsParam);
            return expression;
        }

        private Func<StreamReader, SerializationContext, object> CompileDeserializer()
        {
            var lambda = (Expression<Func<StreamReader, SerializationContext, object>>)this.deserializerExpression.Value;
            var compiledLambda = lambda.Compile();
            return compiledLambda;
        }

        private Action<StreamWriter, SerializationContext, object> CompileSerializer()
        {
            var lambda = (Expression<Action<StreamWriter, SerializationContext, object>>)this.serializerExpression.Value;
            var compiledLambda = lambda.Compile();
            return compiledLambda;
        }

        #endregion
    }
}