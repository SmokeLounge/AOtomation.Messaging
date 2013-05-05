// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerResolverBuilder.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SerializerResolverBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;
    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers.Custom;

    public class SerializerResolverBuilder<T>
    {
        #region Fields

        private readonly Dictionary<Type, ISerializer> serializers;

        #endregion

        #region Constructors and Destructors

        public SerializerResolverBuilder()
        {
            this.serializers = new Dictionary<Type, ISerializer>
                                   {
                                       { typeof(byte), new ByteSerializer() }, 
                                       { typeof(short), new Int16Serializer() }, 
                                       { typeof(int), new Int32Serializer() }, 
                                       { typeof(long), new Int64Serializer() }, 
                                       { typeof(IPAddress), new IPAddressSerializer() }, 
                                       { typeof(float), new SingleSerializer() }, 
                                       { typeof(string), new StringSerializer() }, 
                                       { typeof(ushort), new UInt16Serializer() }, 
                                       { typeof(uint), new UInt32Serializer() }, 
                                       {
                                           typeof(PlayfieldVendorInfo), 
                                           new PlayfieldVendorInfoSerializer()
                                       }, 
                                       {
                                           typeof(SimpleCharFullUpdateMessage), 
                                           new SimpleCharFullUpdateSerializer()
                                       }, 
                                       
                                       
                                       
                                       
                                       
                                       // {
                                       // typeof(OrgClientMessage), 
                                       // new OrgClientMessageSerializer()
                                       // }
                                   };
        }

        #endregion

        #region Public Methods and Operators

        public SerializerResolver Build()
        {
            var rootType = typeof(T);

            var subTypes = rootType.Assembly.GetTypes().Where(rootType.IsAssignableFrom);

            foreach (var subType in subTypes)
            {
                if (this.serializers.ContainsKey(subType))
                {
                    continue;
                }

                var serializer = this.CreateSerializer(subType);
                if (serializer != null)
                {
                    this.serializers.Add(subType, serializer);
                }
            }

            var serializationContext = new SerializerResolver(this.serializers);
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

            var typeSerializerBuilder = new TypeSerializerBuilder(type, this.GetSerializer);
            var typeSerializer = new TypeSerializer(type, typeSerializerBuilder);
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