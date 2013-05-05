// --------------------------------------------------------------------------------------------------------------------
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
            this.SerializerLambda =
                (streamWriter, serializationContext, value) =>
                this.Serialize(streamWriter, serializationContext, value, null);
            this.DeserializerLambda =
                (streamReader, serializationContext) => this.Deserialize(streamReader, serializationContext, null);
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
            StreamReader streamReader, SerializationContext serializationContext, MemberOptions memberOptions)
        {
            var identityType = (IdentityType)streamReader.ReadInt32();
            if (identityType != IdentityType.VendingMachine)
            {
                streamReader.Position = streamReader.Position - 4;
                return null;
            }

            var playfieldVendorInfo = new PlayfieldVendorInfo
                                          {
                                              Unknown1 =
                                                  new Identity
                                                      {
                                                          Type = identityType, 
                                                          Instance = streamReader.ReadInt32()
                                                      }, 
                                              Unknown2 = streamReader.ReadInt32(), 
                                              VendorCount = streamReader.ReadInt32(), 
                                              FirstVendorId = streamReader.ReadInt32()
                                          };
            return playfieldVendorInfo;
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression optionsExpression, 
            Expression assignmentTargetExpression, 
            MemberOptions memberOptions)
        {
            var deserializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <PlayfieldVendorInfoSerializer, Func<StreamReader, SerializationContext, MemberOptions, object>>(
                        o => o.Deserialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, 
                deserializerMethodInfo, 
                new Expression[]
                    {
                        streamReaderExpression, optionsExpression, 
                        Expression.Constant(memberOptions, typeof(MemberOptions))
                    });

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.TypeAs(callExp, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            MemberOptions memberOptions)
        {
            if (value == null)
            {
                return;
            }

            var playfieldVendorInfo = (PlayfieldVendorInfo)value;
            streamWriter.WriteInt32((int)playfieldVendorInfo.Unknown1.Type);
            streamWriter.WriteInt32(playfieldVendorInfo.Unknown1.Instance);
            streamWriter.WriteInt32(playfieldVendorInfo.Unknown2);
            streamWriter.WriteInt32(playfieldVendorInfo.VendorCount);
            streamWriter.WriteInt32(playfieldVendorInfo.FirstVendorId);
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression optionsExpression, 
            Expression valueExpression, 
            MemberOptions memberOptions)
        {
            var serializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <PlayfieldVendorInfoSerializer, Action<StreamWriter, SerializationContext, object, MemberOptions>>(
                        o => o.Serialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, 
                serializerMethodInfo, 
                new[]
                    {
                        streamWriterExpression, optionsExpression, valueExpression, 
                        Expression.Constant(memberOptions, typeof(MemberOptions))
                    });
            return callExp;
        }

        #endregion
    }
}