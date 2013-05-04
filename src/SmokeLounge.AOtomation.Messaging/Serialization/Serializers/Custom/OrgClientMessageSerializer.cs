// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgClientMessageSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgClientMessageSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers.Custom
{
    using System;
    using System.Linq.Expressions;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;

    public class OrgClientMessageSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public OrgClientMessageSerializer()
        {
            this.type = typeof(OrgClientMessage);
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
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            var deserializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo<OrgClientMessageSerializer, Func<StreamReader, SerializationOptions, object>>(
                        o => o.Deserialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, deserializerMethodInfo, new Expression[] { streamReaderExpression, optionsExpression });

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.TypeAs(callExp, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            var serializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo<OrgClientMessageSerializer, Action<StreamWriter, SerializationOptions, object>>(
                        o => o.Serialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, 
                serializerMethodInfo, 
                new[] { streamWriterExpression, optionsExpression, valueExpression });
            return callExp;
        }

        #endregion

        #region Methods

        private object Deserialize(StreamReader reader, SerializationOptions options)
        {
            var orgClientMessage = new OrgClientMessage();

            // N3Message
            orgClientMessage.N3MessageType = (N3MessageType)reader.ReadInt32();
            orgClientMessage.Identity = new Identity
                                            {
                                                Type = (IdentityType)reader.ReadInt32(), 
                                                Instance = reader.ReadInt32()
                                            };
            orgClientMessage.Unknown = reader.ReadByte();

            // OrgClientMessage
            orgClientMessage.Command = (OrgClientCommand)reader.ReadByte();
            orgClientMessage.Target = new Identity
                                          {
                                              Type = (IdentityType)reader.ReadInt32(), 
                                              Instance = reader.ReadInt32()
                                          };
            orgClientMessage.Unknown1 = reader.ReadInt32();

            switch (orgClientMessage.Command)
            {
                case OrgClientCommand.Create:
                case OrgClientCommand.StartVote:
                case OrgClientCommand.Vote:
                case OrgClientCommand.Kick:
                case OrgClientCommand.Tax:
                case OrgClientCommand.BankAdd:
                case OrgClientCommand.BankRemove:
                case OrgClientCommand.BankPaymembers:
                case OrgClientCommand.History:
                case OrgClientCommand.Objective:
                case OrgClientCommand.Description:
                case OrgClientCommand.Name:
                case OrgClientCommand.GoverningForm:
                case OrgClientCommand.StopVote:
                    var commandArgsLength = reader.ReadInt16();
                    orgClientMessage.CommandArgs = reader.ReadString(commandArgsLength);
                    break;
            }

            return orgClientMessage;
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object value)
        {
            var orgClientMessage = (OrgClientMessage)value;

            // N3Message
            writer.WriteInt32((int)orgClientMessage.N3MessageType);
            writer.WriteInt32((int)orgClientMessage.Identity.Type);
            writer.WriteInt32(orgClientMessage.Identity.Instance);
            writer.WriteByte(orgClientMessage.Unknown);

            // OrgClientMessage
            writer.WriteByte((byte)orgClientMessage.Command);
            writer.WriteInt32((int)orgClientMessage.Target.Type);
            writer.WriteInt32(orgClientMessage.Target.Instance);
            writer.WriteInt32(orgClientMessage.Unknown1);

            switch (orgClientMessage.Command)
            {
                case OrgClientCommand.Create:
                case OrgClientCommand.StartVote:
                case OrgClientCommand.Vote:
                case OrgClientCommand.Kick:
                case OrgClientCommand.Tax:
                case OrgClientCommand.BankAdd:
                case OrgClientCommand.BankRemove:
                case OrgClientCommand.BankPaymembers:
                case OrgClientCommand.History:
                case OrgClientCommand.Objective:
                case OrgClientCommand.Description:
                case OrgClientCommand.Name:
                case OrgClientCommand.GoverningForm:
                case OrgClientCommand.StopVote:
                    writer.WriteInt16((short)orgClientMessage.CommandArgs.Length);
                    writer.WriteString(orgClientMessage.CommandArgs);
                    break;
            }
        }

        #endregion
    }
}