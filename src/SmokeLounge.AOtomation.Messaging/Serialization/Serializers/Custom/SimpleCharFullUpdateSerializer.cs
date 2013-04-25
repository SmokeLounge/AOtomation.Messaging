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
            var deserializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo<SimpleCharFullUpdateSerializer, Func<StreamReader, SerializationOptions, object>>(
                        o => o.Deserialize);
            var serializerExp = Expression.New(this.GetType());
            var callExp = Expression.Call(
                serializerExp, deserializerMethodInfo, new Expression[] { streamReaderExpression, optionsExpression });

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.TypeAs(callExp, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            var serializerMethodInfo =
                ReflectionHelper
                    .GetMethodInfo<SimpleCharFullUpdateSerializer, Action<StreamWriter, SerializationOptions, object>>(
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
            throw new NotSupportedException("Deserializing SimpleCharFullUpdateMessage is not supported yet.");
        }

        private void Serialize(StreamWriter writer, SerializationOptions options, object value)
        {
            var scfu = (SimpleCharFullUpdateMessage)value;

            // N3Message
            writer.WriteInt32((int)scfu.N3MessageType);
            writer.WriteInt32((int)scfu.Identity.IdentityType);
            writer.WriteInt32(scfu.Identity.Instance);
            writer.WriteByte(scfu.Unknown);

            // SCFU
            writer.WriteByte(scfu.Version);
            writer.WriteInt32((int)scfu.Flags); // Will update the flags later

            var flags = SimpleCharFullUpdateFlags.None;

            if (scfu.PlayfieldId.HasValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasPlayfieldId;
                writer.WriteInt32(scfu.PlayfieldId.Value);
            }

            if (scfu.FightingTarget != null)
            {
                flags |= SimpleCharFullUpdateFlags.HasFightingTarget;
                writer.WriteInt32((int)scfu.Identity.IdentityType);
                writer.WriteInt32(scfu.Identity.Instance);
            }

            writer.WriteSingle(scfu.Coordinates.X);
            writer.WriteSingle(scfu.Coordinates.Y);
            writer.WriteSingle(scfu.Coordinates.Z);

            if (scfu.Heading != null)
            {
                flags |= SimpleCharFullUpdateFlags.HasHeading;
                writer.WriteSingle(scfu.Heading.X);
                writer.WriteSingle(scfu.Heading.Y);
                writer.WriteSingle(scfu.Heading.Z);
                writer.WriteSingle(scfu.Heading.W);
            }

            writer.WriteUInt32(scfu.Appearance.Value);

            writer.WriteByte((byte)(scfu.Name.Length + 1));
            writer.WriteString(scfu.Name, scfu.Name.Length + 1);

            writer.WriteInt32((int)scfu.CharacterFlags);
            writer.WriteInt16(scfu.AccountFlags);
            writer.WriteInt16(scfu.Expansions);

            var snpc = scfu.CharacterInfo as SimpleNpcInfo;
            if (snpc != null)
            {
                flags |= SimpleCharFullUpdateFlags.IsNpc;
                if (snpc.Family > byte.MaxValue)
                {
                    flags |= SimpleCharFullUpdateFlags.HasExtendedNpcFamily;
                    writer.WriteInt16(snpc.Family);
                }
                else
                {
                    writer.WriteByte((byte)snpc.Family);
                }

                if (snpc.LosHeight > byte.MaxValue)
                {
                    flags |= SimpleCharFullUpdateFlags.HasExtendedNpcLosHeight;
                    writer.WriteInt16(snpc.Family);
                }
                else
                {
                    writer.WriteByte((byte)snpc.LosHeight);
                }
            }

            var spc = scfu.CharacterInfo as SimplePcInfo;
            if (spc != null)
            {
                writer.WriteUInt32(spc.CurrentNano);
                writer.WriteInt32(spc.Team);
                writer.WriteInt16(spc.Swim);

                writer.WriteInt16(spc.StrengthBase);
                writer.WriteInt16(spc.AgilityBase);
                writer.WriteInt16(spc.StaminaBase);
                writer.WriteInt16(spc.IntelligenceBase);
                writer.WriteInt16(spc.SenseBase);
                writer.WriteInt16(spc.PsychicBase);

                if (scfu.CharacterFlags.HasFlag(CharacterFlags.HasVisibleName))
                {
                    writer.WriteInt16((short)spc.FirstName.Length);
                    writer.WriteString(spc.FirstName);
                    writer.WriteInt16((short)spc.LastName.Length);
                    writer.WriteString(spc.LastName);
                }

                if (string.IsNullOrWhiteSpace(spc.OrgName) == false)
                {
                    flags |= SimpleCharFullUpdateFlags.HasOrgName;
                    writer.WriteInt16((short)spc.OrgName.Length);
                    writer.WriteString(spc.OrgName);
                }
            }

            if (scfu.Level > sbyte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasExtendedLevel;
                writer.WriteInt16(scfu.Level);
            }
            else
            {
                writer.WriteByte((byte)scfu.Level);
            }

            if (scfu.Health <= short.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasSmallHealth;
                writer.WriteInt16((short)scfu.Health);
            }
            else
            {
                writer.WriteUInt32(scfu.Health);
            }

            if (scfu.HealthDamage <= byte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasSmallHealthDamage;
                writer.WriteByte((byte)scfu.HealthDamage);
            }
            else
            {
                if (flags.HasFlag(SimpleCharFullUpdateFlags.HasSmallHealth))
                {
                    writer.WriteInt16((short)scfu.HealthDamage);
                }
                else
                {
                    writer.WriteInt32(scfu.HealthDamage);
                }
            }

            writer.WriteUInt32(scfu.MonsterData);
            writer.WriteInt16(scfu.MonsterScale);
            writer.WriteInt16(scfu.VisualFlags);
            writer.WriteByte(scfu.VisibleTitle);

            writer.WriteInt32(scfu.Unknown1.Length);
            writer.WriteBytes(scfu.Unknown1);

            if (scfu.HeadMesh.HasValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasHeadMesh;
                writer.WriteUInt32(scfu.HeadMesh.Value);
            }

            if (scfu.RunSpeedBase > sbyte.MaxValue)
            {
                flags |= SimpleCharFullUpdateFlags.HasExtendedRunSpeed;
                writer.WriteInt16(scfu.RunSpeedBase);
            }
            else
            {
                writer.WriteByte((byte)scfu.RunSpeedBase);
            }

            writer.WriteInt32((scfu.ActiveNanos.Length + 1) * 0x3F1);
            foreach (var activeNano in scfu.ActiveNanos)
            {
                writer.WriteInt32(activeNano.NanoId);
                writer.WriteInt32(activeNano.NanoInstance);
                writer.WriteInt32(activeNano.Time1);
                writer.WriteInt32(activeNano.Time2);
            }

            writer.WriteInt32((scfu.Textures.Length + 1) * 0x3F1);
            foreach (var texture in scfu.Textures)
            {
                writer.WriteInt32(texture.Place);
                writer.WriteInt32(texture.Id);
                writer.WriteInt32(texture.Unknown);
            }

            writer.WriteInt32((scfu.Meshes.Length + 1) * 0x3F1);
            foreach (var mesh in scfu.Meshes)
            {
                writer.WriteByte(mesh.Position);
                writer.WriteUInt32(mesh.Id);
                writer.WriteInt32(mesh.OverrideTextureId);
                writer.WriteByte(mesh.Layer);
            }

            writer.WriteInt32(scfu.Flags2);
            writer.WriteByte(scfu.Unknown2);

            var pos = writer.Position;
            writer.Position = 30;
            writer.WriteInt32((int)flags);
            writer.Position = pos;
        }

        #endregion
    }
}