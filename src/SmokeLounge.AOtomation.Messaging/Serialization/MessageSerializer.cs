// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System.IO;

    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;

    public class MessageSerializer
    {
        #region Fields

        private readonly HeaderSerializer headerSerializer;

        private readonly PacketInspector packetInspector;

        private readonly SerializerResolver serializerResolver;

        #endregion

        #region Constructors and Destructors

        public MessageSerializer()
        {
            this.packetInspector = new PacketInspector();
            this.serializerResolver = new SerializerResolverBuilder<MessageBody>().Build();
            this.headerSerializer = new HeaderSerializer();
        }

        public MessageSerializer(SerializerResolverBuilder serializerResolverBuilder)
        {
            this.packetInspector = new PacketInspector();
            this.serializerResolver = serializerResolverBuilder.Build();
            this.headerSerializer = new HeaderSerializer();
        }

        #endregion

        #region Public Methods and Operators

        public Message Deserialize(Stream stream)
        {
            SerializationContext ignore;
            return this.Deserialize(stream, out ignore);
        }

        public Message Deserialize(Stream stream, out SerializationContext serializationContext)
        {
            serializationContext = null;
            var reader = new StreamReader(stream) { Position = 0 };
            var subTypeInfo = this.packetInspector.FindSubType(reader);

            if (subTypeInfo == null)
            {
                return null;
            }

            var serializer = this.serializerResolver.GetSerializer(subTypeInfo.Type);
            if (serializer == null)
            {
                return null;
            }

            reader.Position = 0;
            serializationContext = new SerializationContext(this.serializerResolver);
            var message = new Message
                              {
                                  Header = (Header)this.headerSerializer.Deserialize(reader, serializationContext), 
                                  Body = (MessageBody)serializer.Deserialize(reader, serializationContext)
                              };
            return message;
        }

        public void Serialize(Stream stream, Message message)
        {
            SerializationContext ignore;
            this.Serialize(stream, message, out ignore);
        }

        public void Serialize(Stream stream, Message message, out SerializationContext serializationContext)
        {
            serializationContext = null;
            var serializer = this.serializerResolver.GetSerializer(message.Body.GetType());
            if (serializer == null)
            {
                return;
            }

            serializationContext = new SerializationContext(this.serializerResolver);
            var writer = new StreamWriter(stream) { Position = 0 };
            this.headerSerializer.Serialize(writer, serializationContext, message.Header);
            serializer.Serialize(writer, serializationContext, message.Body);
            var length = writer.Position;
            writer.Position = 6;
            writer.WriteInt16((short)length);
        }

        #endregion
    }
}