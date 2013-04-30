// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleCharFullUpdateMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SimpleCharFullUpdateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.SimpleCharFullUpdate)]
    public class SimpleCharFullUpdateMessage : N3Message
    {
        #region Constructors and Destructors

        public SimpleCharFullUpdateMessage()
        {
            this.N3MessageType = N3MessageType.SimpleCharFullUpdate;
            this.Unknown = 0x00;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public byte Version { get; set; }

        [AoMember(1)]
        public SimpleCharFullUpdateFlags Flags { get; set; }

        [AoMember(2)]
        public int? PlayfieldId { get; set; }

        [AoMember(3)]
        public Identity FightingTarget { get; set; }

        [AoMember(4)]
        public Vector3 Coordinates { get; set; }

        [AoMember(5)]
        public Quaternion Heading { get; set; }

        [AoMember(6)]
        public Appearance Appearance { get; set; }

        [AoMember(7)]
        public string Name { get; set; }

        [AoMember(8)]
        public CharacterFlags CharacterFlags { get; set; }

        [AoMember(9)]
        public short AccountFlags { get; set; }

        [AoMember(10)]
        public short Expansions { get; set; }

        [AoMember(11)]
        public SimpleCharacterInfo CharacterInfo { get; set; }

        [AoMember(12)]
        public short Level { get; set; }

        [AoMember(13)]
        public uint Health { get; set; }

        [AoMember(14)]
        public int HealthDamage { get; set; }

        [AoMember(15)]
        public uint MonsterData { get; set; }

        [AoMember(16)]
        public short MonsterScale { get; set; }

        [AoMember(17)]
        public short VisualFlags { get; set; }

        [AoMember(18)]
        public byte VisibleTitle { get; set; }

        [AoMember(19, SerializeSize = ArraySizeType.Int32)]
        public byte[] Unknown1 { get; set; }

        [AoMember(20)]
        public uint? HeadMesh { get; set; }

        [AoMember(21)]
        public short RunSpeedBase { get; set; }

        [AoMember(22, SerializeSize = ArraySizeType.X3F1)]
        public ActiveNano[] ActiveNanos { get; set; }

        [AoMember(23, SerializeSize = ArraySizeType.X3F1)]
        public Texture[] Textures { get; set; }

        [AoMember(24, SerializeSize = ArraySizeType.X3F1)]
        public Mesh[] Meshes { get; set; }

        [AoMember(25)]
        public int Flags2 { get; set; }

        [AoMember(26)]
        public byte Unknown2 { get; set; }

        #endregion
    }
}