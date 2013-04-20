// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeSerializerBuilder.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TypeSerializerBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class TypeSerializerBuilder
    {
        #region Fields

        private readonly ConstructorInfo constructor;

        private readonly Lazy<PropertyMeta[]> propertyMetas;

        private readonly Func<Type, ISerializer> serializerResolver;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public TypeSerializerBuilder(Type type, Func<Type, ISerializer> serializerResolver)
        {
            this.type = type;
            this.serializerResolver = serializerResolver;
            this.constructor = type.GetConstructor(new Type[] { });
            this.propertyMetas = new Lazy<PropertyMeta[]>(this.InitializePropertyMetas);
        }

        #endregion

        #region Public Methods and Operators

        public Expression BuildDeserializer(
            ParameterExpression streamReaderExpression, ParameterExpression optionsExpression)
        {
            var deserializedObject = Expression.Variable(this.type, "serializerVar");

            var createInstance = Expression.Assign(deserializedObject, Expression.New(this.constructor));
            var deserializationExpressions = new List<Expression> { createInstance };

            foreach (var propertyMeta in this.propertyMetas.Value)
            {
                var propertySerializer = this.serializerResolver(propertyMeta.Type);
                var optionsConst = Expression.Constant(propertyMeta.Options);
                Expression propertyExpression = Expression.Property(deserializedObject, propertyMeta.Property);
                var deserializerExpression = propertySerializer.DeserializerExpression(
                    streamReaderExpression, optionsConst, propertyExpression);
                deserializationExpressions.Add(deserializerExpression);
            }

            var returnTarget = Expression.Label(typeof(object));
            var returnExpression = Expression.Return(returnTarget, deserializedObject, typeof(object));
            var returnLabel = Expression.Label(returnTarget, deserializedObject);

            deserializationExpressions.Add(returnExpression);
            deserializationExpressions.Add(returnLabel);

            var deserialization = Expression.Block(new[] { deserializedObject }, deserializationExpressions);
            var deserializationLambda =
                Expression.Lambda<Func<StreamReader, SerializationOptions, object>>(
                    deserialization, streamReaderExpression, optionsExpression);
            return deserializationLambda;
        }

        public Expression BuildSerializer(
            ParameterExpression streamWriterExpression, ParameterExpression optionsExpression)
        {
            var objectParam = Expression.Parameter(typeof(object), "object");
            var objectToSerialize = Expression.Variable(this.type, "serializerVar");

            var unboxObject = Expression.Assign(objectToSerialize, Expression.Convert(objectParam, this.type));
            var serializationExpressions = new List<Expression> { unboxObject };

            foreach (var propertyMeta in this.propertyMetas.Value)
            {
                var propertySerializer = this.serializerResolver(propertyMeta.Type);
                var optionsConst = Expression.Constant(propertyMeta.Options);
                Expression propertyExpression = Expression.Property(objectToSerialize, propertyMeta.Property);
                var serializerExpression = propertySerializer.SerializerExpression(
                    streamWriterExpression, optionsConst, propertyExpression);
                serializationExpressions.Add(serializerExpression);
            }

            var serialization = Expression.Block(new[] { objectToSerialize }, serializationExpressions);
            var serializationLambda =
                Expression.Lambda<Action<StreamWriter, SerializationOptions, object>>(
                    serialization, streamWriterExpression, optionsExpression, objectParam);
            return serializationLambda;
        }

        #endregion

        #region Methods

        private PropertyMeta[] InitializePropertyMetas()
        {
            var baseType = this.type;
            var stack = new Stack<Type>();
            do
            {
                stack.Push(baseType);
                baseType = baseType.BaseType;
            }
            while (baseType != null);

            var list = new List<PropertyMeta>();

            while (stack.Count > 0)
            {
                var t = stack.Pop();
                var p = from property in t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        let memberAttribute =
                            property.GetCustomAttributes(typeof(AoMemberAttribute), false)
                                    .Cast<AoMemberAttribute>()
                                    .FirstOrDefault()
                        where property.CanWrite && memberAttribute != null && property.DeclaringType == t
                        orderby memberAttribute.Order ascending
                        select new PropertyMeta(property, memberAttribute);
                list.AddRange(p);
            }

            return list.ToArray();
        }

        #endregion
    }
}