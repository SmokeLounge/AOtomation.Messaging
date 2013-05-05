// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgInfoPacketMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgInfoPacketMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.OrgInfoPacket)]
    public class OrgInfoPacketMessage : N3Message
    {
        #region Constructors and Destructors

        public OrgInfoPacketMessage()
        {
            this.N3MessageType = N3MessageType.OrgInfoPacket;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0, SerializeSize = ArraySizeType.Int16)]
        public string Name { get; set; }

        #endregion
    }
}