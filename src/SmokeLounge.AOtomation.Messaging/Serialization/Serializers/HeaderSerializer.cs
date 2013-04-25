// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the HeaderSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;

    using SmokeLounge.AOtomation.Messaging.Messages;

    public class HeaderSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public HeaderSerializer()
        {
            this.type = typeof(Header);
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
            throw new NotImplementedException();
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        private object Deserialize(StreamReader reader, SerializationOptions options)
        {
            var header = new Header();
            header.MessageId = reader.ReadInt16();
            header.PacketType = (PacketType)reader.ReadInt16();
            header.Unknown = reader.ReadInt16();
            header.Size = reader.ReadInt16();
            header.Sender = reader.ReadInt32();
            header.Receiver = reader.ReadInt32();
            return header;
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object value)
        {
            var header = (Header)value;
            writer.WriteInt16(header.MessageId);
            writer.WriteInt16((short)header.PacketType);
            writer.WriteInt16(header.Unknown);
            writer.WriteInt16(header.Size);
            writer.WriteInt32(header.Sender);
            writer.WriteInt32(header.Receiver);
        }

        #endregion
    }
}