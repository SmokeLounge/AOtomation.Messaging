﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgClientMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgClientMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.OrgClient)]
    public class OrgClientMessage : N3Message
    {
        #region Constructors and Destructors

        public OrgClientMessage()
        {
            this.N3MessageType = N3MessageType.OrgClient;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public OrgClientCommand Command { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.Int16)]
        public string CommandArgs { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(2)]
        public int Unknown1 { get; set; }

        #endregion
    }
}