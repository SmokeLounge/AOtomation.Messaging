// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoneRedirectionMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ZoneRedirectionMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.ZoneRedirection)]
    public class ZoneRedirectionMessage : SystemMessage
    {
        #region Constructors and Destructors

        public ZoneRedirectionMessage()
        {
            this.SystemMessageType = SystemMessageType.ZoneRedirection;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public int CharacterId { get; set; }

        [AoMember(1, FixedSizeLength = 4)]
        public byte[] ServerIpAddress { get; set; }

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