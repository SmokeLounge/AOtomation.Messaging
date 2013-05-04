// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SystemMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)PacketType.SystemMessage)]
    [AoKnownType(16, IdentifierType.Int32)]
    public abstract class SystemMessage : MessageBody
    {
        #region Public Properties

        public override PacketType PacketType
        {
            get
            {
                return PacketType.SystemMessage;
            }
        }

        [AoMember(0)]
        public SystemMessageType SystemMessageType { get; set; }

        #endregion
    }
}