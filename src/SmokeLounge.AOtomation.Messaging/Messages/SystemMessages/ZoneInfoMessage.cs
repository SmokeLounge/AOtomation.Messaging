// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoneInfoMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ZoneInfoMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using System.Net;

    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)SystemMessageType.ZoneInfo)]
    public class ZoneInfoMessage : SystemMessage
    {
        #region Constructors and Destructors

        public ZoneInfoMessage()
        {
            this.SystemMessageType = SystemMessageType.ZoneInfo;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public int CharacterId { get; set; }

        [AoMember(1)]
        public IPAddress ServerIpAddress { get; set; }

        [AoMember(2)]
        public ushort ServerPort { get; set; }

        [AoMember(3)]
        public short Unknown1 { get; set; }

        [AoMember(4)]
        public int Unknown2 { get; set; }

        [AoMember(5)]
        public int Unknown3 { get; set; }

        #endregion
    }
}