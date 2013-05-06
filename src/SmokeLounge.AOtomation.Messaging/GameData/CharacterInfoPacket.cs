// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterInfoPacket.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharacterInfoPacket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class CharacterInfoPacket : InfoPacket
    {
        #region AoMember Properties

        [AoMember(0)]
        public byte Unknown1 { get; set; }

        [AoMember(1)]
        [AoUsesFlags("flags", typeof(byte), FlagsCriteria.Default)]
        public Profession Profession { get; set; }

        [AoMember(2)]
        public byte Level { get; set; }

        [AoMember(3)]
        public byte TitleLevel { get; set; }

        [AoMember(4)]
        [AoUsesFlags("flags", typeof(byte), FlagsCriteria.Default)]
        public Profession VisualProfession { get; set; }

        [AoMember(5)]
        public short SideXp { get; set; }

        [AoMember(6)]
        public int Health { get; set; }

        [AoMember(7)]
        public int MaxHealth { get; set; }

        [AoMember(8)]
        public int BreedHostility { get; set; }

        [AoMember(9)]
        [AoUsesFlags("flags", typeof(int), FlagsCriteria.EqualsToAny, 
            new[]
                {
                    (int)InfoPacketType.CharacterOrg, (int)InfoPacketType.CharacterOrgSite, 
                    (int)InfoPacketType.CharacterOrgSiteTower
                })]
        public int? OrganizationId { get; set; }

        [AoMember(10, SerializeSize = ArraySizeType.Int16)]
        public string FirstName { get; set; }

        [AoMember(11, SerializeSize = ArraySizeType.Int16)]
        public string LastName { get; set; }

        [AoMember(12, SerializeSize = ArraySizeType.Int16)]
        public string LegacyTitle { get; set; }

        [AoMember(13)]
        public short Unknown2 { get; set; }

        [AoMember(14, SerializeSize = ArraySizeType.Int16)]
        [AoUsesFlags("flags", typeof(string), FlagsCriteria.EqualsToAny, 
            new[]
                {
                    (int)InfoPacketType.CharacterOrg, (int)InfoPacketType.CharacterOrgSite, 
                    (int)InfoPacketType.CharacterOrgSiteTower
                })]
        public string OrganizationRank { get; set; }

        [AoMember(15, SerializeSize = ArraySizeType.X3F1)]
        [AoUsesFlags("flags", typeof(TowerField[]), FlagsCriteria.EqualsToAny, 
            new[] { (int)InfoPacketType.CharacterOrgSite, (int)InfoPacketType.CharacterOrgSiteTower })]
        public TowerField[] TowerFields { get; set; }

        [AoMember(16)]
        public int CityPlayfieldId { get; set; }

        [AoMember(17, SerializeSize = ArraySizeType.X3F1)]
        [AoUsesFlags("flags", typeof(Tower[]), FlagsCriteria.EqualsToAny, 
            new[] { (int)InfoPacketType.CharacterOrgSiteTower })]
        public Tower[] Towers { get; set; }

        [AoMember(18)]
        public int InvadersKilled { get; set; }

        [AoMember(19)]
        public int KilledByInvaders { get; set; }

        [AoMember(20)]
        public int AiLevel { get; set; }

        [AoMember(21)]
        public int PvpDuelWins { get; set; }

        [AoMember(22)]
        public int PvpDuelLoses { get; set; }

        [AoMember(23)]
        public int PvpProfessionDuelLoses { get; set; }

        [AoMember(24)]
        public int PvpSoloKills { get; set; }

        [AoMember(25)]
        public int PvpTeamKills { get; set; }

        [AoMember(26)]
        public int PvpSoloScore { get; set; }

        [AoMember(27)]
        public int PvpTeamScore { get; set; }

        [AoMember(28)]
        public int PvpDuelScore { get; set; }

        #endregion
    }
}