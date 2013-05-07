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
            this.SerializerLambda =
                (streamWriter, serializationContext, value) => this.Serialize(streamWriter, serializationContext, value);
            this.DeserializerLambda =
                (streamReader, serializationContext) => this.Deserialize(streamReader, serializationContext);
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationContext, object> DeserializerLambda { get; private set; }

        public Action<StreamWriter, SerializationContext, object> SerializerLambda { get; private set; }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public object Deserialize(
            StreamReader streamReader, SerializationContext serializationContext, MemberOptions memberOptions = null)
        {
            var header = new Header();
            header.MessageId = streamReader.ReadInt16();
            header.PacketType = (PacketType)streamReader.ReadInt16();
            header.Unknown = streamReader.ReadInt16();
            header.Size = streamReader.ReadInt16();
            header.Sender = streamReader.ReadInt32();
            header.Receiver = streamReader.ReadInt32();
            return header;
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            throw new NotImplementedException();
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            MemberOptions memberOptions = null)
        {
            var header = (Header)value;
            streamWriter.WriteInt16(header.MessageId);
            streamWriter.WriteInt16((short)header.PacketType);
            streamWriter.WriteInt16(header.Unknown);
            streamWriter.WriteInt16(header.Size);
            streamWriter.WriteInt32(header.Sender);
            streamWriter.WriteInt32(header.Receiver);
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}