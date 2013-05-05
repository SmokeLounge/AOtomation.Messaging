﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayfieldVendorInfoSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayfieldVendorInfoSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers.Custom
{
    using System;
    using System.Linq.Expressions;

    using SmokeLounge.AOtomation.Messaging.GameData;

    // TODO: Investigate whether this can be implemented using a CanBeNullAttribute
    public class PlayfieldVendorInfoSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public PlayfieldVendorInfoSerializer()
        {
            this.type = typeof(PlayfieldVendorInfo);
            this.Serializer = this.Serialize;
            this.Deserializer = this.Deserialize;
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationContext, object> Deserializer { get; private set; }

        public Action<StreamWriter, SerializationContext, object> Serializer { get; private set; }

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
                    .GetMethodInfo<PlayfieldVendorInfoSerializer, Func<StreamReader, SerializationContext, object>>(
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
                    .GetMethodInfo<PlayfieldVendorInfoSerializer, Action<StreamWriter, SerializationContext, object>>(
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

        private object Deserialize(StreamReader reader, SerializationContext context)
        {
            var identityType = (IdentityType)reader.ReadInt32();
            if (identityType != IdentityType.VendingMachine)
            {
                reader.Position = reader.Position - 4;
                return null;
            }

            var playfieldVendorInfo = new PlayfieldVendorInfo
                                          {
                                              Unknown1 =
                                                  new Identity
                                                      {
                                                          Type = identityType, 
                                                          Instance = reader.ReadInt32()
                                                      }, 
                                              Unknown2 = reader.ReadInt32(), 
                                              VendorCount = reader.ReadInt32(), 
                                              FirstVendorId = reader.ReadInt32()
                                          };
            return playfieldVendorInfo;
        }

        private void Serialize(StreamWriter writer, SerializationContext context, object value)
        {
            if (value == null)
            {
                return;
            }

            var playfieldVendorInfo = (PlayfieldVendorInfo)value;
            writer.WriteInt32((int)playfieldVendorInfo.Unknown1.Type);
            writer.WriteInt32(playfieldVendorInfo.Unknown1.Instance);
            writer.WriteInt32(playfieldVendorInfo.Unknown2);
            writer.WriteInt32(playfieldVendorInfo.VendorCount);
            writer.WriteInt32(playfieldVendorInfo.FirstVendorId);
        }

        #endregion
    }
}