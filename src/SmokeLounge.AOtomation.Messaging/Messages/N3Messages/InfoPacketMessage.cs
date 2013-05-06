// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfoPacketMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InfoPacketMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.InfoPacket)]
    public class InfoPacketMessage : N3Message
    {
        #region Constructors and Destructors

        public InfoPacketMessage()
        {
            this.N3MessageType = N3MessageType.InfoPacket;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        [AoFlags("flags")]
        public InfoPacketType Type { get; set; }

        [AoMember(1)]
        [AoUsesFlags("flags", typeof(CharacterInfoPacket), FlagsCriteria.EqualsToAny, 
            new[]
                {
                    (int)InfoPacketType.Character, (int)InfoPacketType.CharacterOrg, (int)InfoPacketType.CharacterOrgSite, 
                    (int)InfoPacketType.CharacterOrgSiteTower
                })]
        [AoUsesFlags("flags", typeof(MonsterInfoPacket), FlagsCriteria.EqualsToAny, 
            new[] { (int)InfoPacketType.Monster, })]
        [AoUsesFlags("flags", typeof(TowerInfoPacket), FlagsCriteria.EqualsToAny, 
            new[] { (int)InfoPacketType.Tower, (int)InfoPacketType.ControlTower })]
        public InfoPacket Info { get; set; }

        #endregion
    }
}