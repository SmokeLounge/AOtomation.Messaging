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
    using System.Net;

    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

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
        public IPAddress ServerIpAddress { get; set; }

        [AoMember(1)]
        public ushort ServerPort { get; set; }

        #endregion
    }
}