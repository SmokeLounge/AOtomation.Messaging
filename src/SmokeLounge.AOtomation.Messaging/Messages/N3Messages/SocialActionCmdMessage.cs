// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SocialActionCmdMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SocialActionCmdMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.SocialActionCmd)]
    public class SocialActionCmdMessage : N3Message
    {
        #region Constructors and Destructors

        public SocialActionCmdMessage()
        {
            this.N3MessageType = N3MessageType.SocialActionCmd;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public byte Unknown1 { get; set; }

        [AoMember(1)]
        public byte Unknown2 { get; set; }

        [AoMember(2)]
        public byte Unknown3 { get; set; }

        [AoMember(3)]
        public byte Unknown4 { get; set; }

        [AoMember(4)]
        public int Unknown5 { get; set; }

        [AoMember(5)]
        public SocialAction Action { get; set; }

        #endregion
    }
}