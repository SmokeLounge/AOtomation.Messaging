// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TowerInfoPacket.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TowerInfoPacket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class TowerInfoPacket : InfoPacket
    {
        #region AoMember Properties

        [AoMember(0)]
        public byte Unknown1 { get; set; }

        [AoMember(1)]
        public byte Unknown2 { get; set; }

        [AoMember(2)]
        public byte Unknown3 { get; set; }

        [AoMember(3)]
        public byte Unknown4 { get; set; }

        [AoMember(4)]
        public byte Unknown5 { get; set; }

        [AoMember(5)]
        public byte Unknown6 { get; set; }

        [AoMember(6)]
        public byte Unknown7 { get; set; }

        [AoMember(7)]
        public int Health { get; set; }

        [AoMember(8)]
        public int MaxHealth { get; set; }

        [AoMember(9)]
        public int Unknown8 { get; set; }

        [AoMember(10)]
        public int OrganizationId { get; set; }

        [AoMember(11)]
        public short Unknown9 { get; set; }

        [AoMember(12)]
        public short Unknown10 { get; set; }

        [AoMember(13)]
        public short Unknown11 { get; set; }

        [AoMember(14, SerializeSize = ArraySizeType.Int16)]
        public byte[] FormattedText { get; set; }

        [AoMember(15)]
        public int TowerCount3F1 { get; set; }

        [AoMember(16)]
        public int TowerLowId { get; set; }

        [AoMember(17)]
        public int TowerHighId { get; set; }

        [AoMember(18)]
        public int TowerQuality { get; set; }

        [AoMember(19)]
        public int Unknown12 { get; set; }

        [AoMember(20)]
        [AoUsesFlags("flags", typeof(int), FlagsCriteria.EqualsToAny, new[] { (int)InfoPacketType.ControlTower })]
        public int? Timer { get; set; }

        [AoMember(21)]
        [AoUsesFlags("flags", typeof(byte), FlagsCriteria.EqualsToAny, new[] { (int)InfoPacketType.ControlTower })]
        public byte? Unknown13 { get; set; }

        [AoMember(22)]
        public int Unknown14 { get; set; }

        [AoMember(23)]
        public int Unknown15 { get; set; }

        [AoMember(24)]
        public int Unknown16 { get; set; }

        #endregion
    }
}