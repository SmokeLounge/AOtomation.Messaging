// --------------------------------------------------------------------------------------------------------------------
// <copyright file="N3Message.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the N3Message type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)PacketType.N3Message)]
    [AoKnownType(16, IdentifierType.Int32)]
    public abstract class N3Message : MessageBody
    {
        #region Constructors and Destructors

        protected N3Message()
        {
            this.Unknown = 0x01;
        }

        #endregion

        #region Public Properties

        [AoMember(1)]
        public Identity Identity { get; set; }

        [AoMember(0)]
        public N3MessageType N3MessageType { get; set; }

        public override PacketType PacketType
        {
            get
            {
                return PacketType.N3Message;
            }
        }

        [AoMember(2)]
        public byte Unknown { get; set; }

        #endregion
    }
}