// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationContextBuilder.cs" company="SmokeLounge">
//   Copyright � 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SerializationContextBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;

    public class SerializationContextBuilder<T>
    {
        #region Fields

        private readonly Dictionary<Type, ISerializer> serializers;

        #endregion

        #region Constructors and Destructors

        public SerializationContextBuilder()
        {
            this.serializers = new Dictionary<Type, ISerializer>
                                   {
                                       { typeof(byte), new ByteSerializer() }, 
                                       { typeof(short), new Int16Serializer() }, 
                                       { typeof(int), new Int32Serializer() }, 
                                       { typeof(long), new Int64Serializer() }, 
                                       { typeof(float), new SingleSerializer() }, 
                                       { typeof(string), new StringSerializer() }, 
                                       { typeof(ushort), new UInt16Serializer() }, 
                                       { typeof(uint), new UInt32Serializer() }
                                   };
        }

        #endregion

        #region Public Methods and Operators

        public SerializationContext Build()
        {
            var rootType = typeof(T);

            var subTypes = rootType.Assembly.GetTypes().Where(rootType.IsAssignableFrom);

            foreach (var subType in subTypes)
            {
                var serializer = this.CreateSerializer(subType);
                if (serializer != null)
                {
                    this.serializers.Add(subType, serializer);
                }
            }

            var serializationContext = new SerializationContext(this.serializers);
            return serializationContext;
        }

        #endregion

        #region Methods

        private ISerializer CreateSerializer(Type type)
        {
            if (type.IsAbstract)
            {
                return null;
            }

            var writerParam = Expression.Parameter(typeof(StreamWriter), "writer");
            var readerParam = Expression.Parameter(typeof(StreamReader), "reader");
            var optionsParam = Expression.Parameter(typeof(SerializationOptions), "options");
            var typeSerializerBuilder = new TypeSerializerBuilder(type, this.GetSerializer);
            var serializerExp = typeSerializerBuilder.BuildSerializer(writerParam, optionsParam);
            var deserializerExp = typeSerializerBuilder.BuildDeserializer(readerParam, optionsParam);

            var typeSerializer = new TypeSerializer(type, serializerExp, deserializerExp);
            return typeSerializer;
        }

        private ISerializer GetSerializer(Type type)
        {
            ISerializer serializer;
            if (this.serializers.TryGetValue(type, out serializer))
            {
                return serializer;
            }

            if (type.IsEnum)
            {
                var enumType = type.GetEnumUnderlyingType();
                if (this.serializers.TryGetValue(enumType, out serializer))
                {
                    return serializer;
                }
            }

            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                serializer = this.GetSerializer(elementType);
                if (serializer == null)
                {
                    return null;
                }

                var arraySerializer = new ArraySerializer(type, serializer);
                this.serializers.Add(type, arraySerializer);
                return arraySerializer;
            }

            serializer = this.CreateSerializer(type);
            if (serializer != null)
            {
                this.serializers.Add(type, serializer);
            }

            return serializer;
        }

        #endregion
    }
}