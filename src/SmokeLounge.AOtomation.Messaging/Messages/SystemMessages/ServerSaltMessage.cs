// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerSaltMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ServerSaltMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.ServerSalt)]
    public class ServerSaltMessage : SystemMessage
    {
        #region Constructors and Destructors

        public ServerSaltMessage()
        {
            this.SystemMessageType = SystemMessageType.ServerSalt;
        }

        #endregion

        #region Public Properties

        [AoMember(0, IsFixedSize = true, FixedSizeLength = 32)]
        public byte[] ServerSalt { get; set; }

        #endregion
    }
}