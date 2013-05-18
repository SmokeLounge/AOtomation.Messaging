// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleCharFullUpdateSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SimpleCharFullUpdateSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers.Custom
{
    using System;
    using System.Linq.Expressions;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;

    // TODO: Check the client side of this message for the possibly missing parts.
    public class SimpleCharFullUpdateSerializer : ISerializer
    {
        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public SimpleCharFullUpdateSerializer()
        {
            this.type = typeof(SimpleCharFullUpdateMessage);
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

        #region Public Methods and Operators

        public object Deserialize(
            StreamReader streamReader, 
            SerializationContext serializationContext, 
            PropertyMetaData propertyMetaData = null)
        {
            return new SimpleCharFullUpdateMessage();
        }

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ParameterExpression serializationContextExpression, 
            Expression assignmentTargetExpression, 
            PropertyMetaData propertyMetaData)
        {
            var deserializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <SimpleCharFullUpdateSerializer, Func<StreamReader, SerializationContext, PropertyMetaData, object>>
                    (o => o.Deserialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, 
                deserializerMethodInfo, 
                new Expression[]
                    {
                        streamReaderExpression, serializationContextExpression, 
                        Expression.Constant(propertyMetaData, typeof(PropertyMetaData))
                    });

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.TypeAs(callExp, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public void Serialize(
            StreamWriter streamWriter, 
            SerializationContext serializationContext, 
            object value, 
            PropertyMetaData propertyMetaData = null)
        {
            var scfu = (SimpleCharFullUpdateMessage)value;

            // N3Message
            streamWriter.WriteInt32((int)scfu.N3MessageType);
            streamWriter.WriteInt32((int)scfu.Identity.Type);
            streamWriter.WriteInt32(scfu.Identity.Instance);
            streamWriter.WriteByte(scfu.Unknown);

            // SCFU
            streamWriter.WriteByte(scfu.Version);
            streamWriter.WriteInt32((int)scfu.Flags); // Will update the flags later

            var flags = SimpleCharFullUpdateFlags.None;

            if (scfu.PlayfieldId.HasValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasPlayfieldId;
                streamWriter.WriteInt32(scfu.PlayfieldId.Value);
            }

            if (scfu.FightingTarget != null)
            {
                flags |= SimpleCharFullUpdateFlags.HasFightingTarget;
                streamWriter.WriteInt32((int)scfu.Identity.Type);
                streamWriter.WriteInt32(scfu.Identity.Instance);
            }

            streamWriter.WriteSingle(scfu.Coordinates.X);
            streamWriter.WriteSingle(scfu.Coordinates.Y);
            streamWriter.WriteSingle(scfu.Coordinates.Z);

            if (scfu.Heading != null)
            {
                flags |= SimpleCharFullUpdateFlags.HasHeading;
                streamWriter.WriteSingle(scfu.Heading.X);
                streamWriter.WriteSingle(scfu.Heading.Y);
                streamWriter.WriteSingle(scfu.Heading.Z);
                streamWriter.WriteSingle(scfu.Heading.W);
            }

            streamWriter.WriteUInt32(scfu.Appearance.Value);

            streamWriter.WriteByte((byte)(scfu.Name.Length + 1));
            streamWriter.WriteString(scfu.Name, scfu.Name.Length + 1);

            streamWriter.WriteInt32((int)scfu.CharacterFlags);
            streamWriter.WriteInt16(scfu.AccountFlags);
            streamWriter.WriteInt16(scfu.Expansions);

            var snpc = scfu.CharacterInfo as SimpleNpcInfo;
            if (snpc != null)
            {
                flags |= SimpleCharFullUpdateFlags.IsNpc;
                if (snpc.Family > byte.MaxValue)
                {
                    flags |= SimpleCharFullUpdateFlags.HasExtendedNpcFamily;
                    streamWriter.WriteInt16(snpc.Family);
                }
                else
                {
                    streamWriter.WriteByte((byte)snpc.Family);
                }

                if (snpc.LosHeight > byte.MaxValue)
                {
                    flags |= SimpleCharFullUpdateFlags.HasExtendedNpcLosHeight;
                    streamWriter.WriteInt16(snpc.Family);
                }
                else
                {
                    streamWriter.WriteByte((byte)snpc.LosHeight);
                }
            }

            var spc = scfu.CharacterInfo as SimplePcInfo;
            if (spc != null)
            {
                streamWriter.WriteUInt32(spc.CurrentNano);
                streamWriter.WriteInt32(spc.Team);
                streamWriter.WriteInt16(spc.Swim);

                streamWriter.WriteInt16(spc.StrengthBase);
                streamWriter.WriteInt16(spc.AgilityBase);
                streamWriter.WriteInt16(spc.StaminaBase);
                streamWriter.WriteInt16(spc.IntelligenceBase);
                streamWriter.WriteInt16(spc.SenseBase);
                streamWriter.WriteInt16(spc.PsychicBase);

                if (scfu.CharacterFlags.HasFlag(CharacterFlags.HasVisibleName))
                {
                    streamWriter.WriteInt16((short)spc.FirstName.Length);
                    streamWriter.WriteString(spc.FirstName);
                    streamWriter.WriteInt16((short)spc.LastName.Length);
                    streamWriter.WriteString(spc.LastName);
                }

                if (string.IsNullOrWhiteSpace(spc.OrgName) == false)
                {
                    flags |= SimpleCharFullUpdateFlags.HasOrgName;
                    streamWriter.WriteInt16((short)spc.OrgName.Length);
                    streamWriter.WriteString(spc.OrgName);
                }
            }

            if (scfu.Level > sbyte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasExtendedLevel;
                streamWriter.WriteInt16(scfu.Level);
            }
            else
            {
                streamWriter.WriteByte((byte)scfu.Level);
            }

            if (scfu.Health <= short.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasSmallHealth;
                streamWriter.WriteInt16((short)scfu.Health);
            }
            else
            {
                streamWriter.WriteUInt32(scfu.Health);
            }

            if (scfu.HealthDamage <= byte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasSmallHealthDamage;
                streamWriter.WriteByte((byte)scfu.HealthDamage);
            }
            else
            {
                if (flags.HasFlag(SimpleCharFullUpdateFlags.HasSmallHealth))
                {
                    streamWriter.WriteInt16((short)scfu.HealthDamage);
                }
                else
                {
                    streamWriter.WriteInt32(scfu.HealthDamage);
                }
            }

            streamWriter.WriteUInt32(scfu.MonsterData);
            streamWriter.WriteInt16(scfu.MonsterScale);
            streamWriter.WriteInt16(scfu.VisualFlags);
            streamWriter.WriteByte(scfu.VisibleTitle);

            streamWriter.WriteInt32(scfu.Unknown1.Length);
            streamWriter.WriteBytes(scfu.Unknown1);

            if (scfu.HeadMesh.HasValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasHeadMesh;
                streamWriter.WriteUInt32(scfu.HeadMesh.Value);
            }

            if (scfu.RunSpeedBase > sbyte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasExtendedRunSpeed;
                streamWriter.WriteInt16(scfu.RunSpeedBase);
            }
            else
            {
                streamWriter.WriteByte((byte)scfu.RunSpeedBase);
            }

            streamWriter.WriteInt32((scfu.ActiveNanos.Length + 1) * 0x3F1);
            foreach (var activeNano in scfu.ActiveNanos)
            {
                streamWriter.WriteInt32(activeNano.NanoId);
                streamWriter.WriteInt32(activeNano.NanoInstance);
                streamWriter.WriteInt32(activeNano.Time1);
                streamWriter.WriteInt32(activeNano.Time2);
            }

            streamWriter.WriteInt32((scfu.Textures.Length + 1) * 0x3F1);
            foreach (var texture in scfu.Textures)
            {
                streamWriter.WriteInt32(texture.Place);
                streamWriter.WriteInt32(texture.Id);
                streamWriter.WriteInt32(texture.Unknown);
            }

            streamWriter.WriteInt32((scfu.Meshes.Length + 1) * 0x3F1);
            foreach (var mesh in scfu.Meshes)
            {
                streamWriter.WriteByte(mesh.Position);
                streamWriter.WriteUInt32(mesh.Id);
                streamWriter.WriteInt32(mesh.OverrideTextureId);
                streamWriter.WriteByte(mesh.Layer);
            }

            streamWriter.WriteInt32(scfu.Flags2);
            streamWriter.WriteByte(scfu.Unknown2);

            var pos = streamWriter.Position;
            streamWriter.Position = 30;
            streamWriter.WriteInt32((int)flags);
            streamWriter.Position = pos;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, 
            ParameterExpression serializationContextExpression, 
            Expression valueExpression, 
            PropertyMetaData propertyMetaData)
        {
            var serializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo
                    <SimpleCharFullUpdateSerializer, 
                        Action<StreamWriter, SerializationContext, object, PropertyMetaData>>(o => o.Serialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, 
                serializerMethodInfo, 
                new[]
                    {
                        streamWriterExpression, serializationContextExpression, valueExpression, 
                        Expression.Constant(propertyMetaData, typeof(PropertyMetaData))
                    });
            return callExp;
        }

        #endregion
    }
}