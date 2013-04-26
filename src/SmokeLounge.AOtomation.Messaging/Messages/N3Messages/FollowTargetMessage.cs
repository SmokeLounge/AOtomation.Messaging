// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FollowTargetMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the FollowTargetMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.FollowTarget)]
    public class FollowTargetMessage : N3Message
    {
        #region Constructors and Destructors

        public FollowTargetMessage()
        {
            this.N3MessageType = N3MessageType.FollowTarget;
        }

        #endregion

        #region Public Properties

        [AoMember(2)]
        public Identity Target { get; set; }

        [AoMember(0)]
        public byte Unknown1 { get; set; }

        [AoMember(1)]
        public byte Unknown2 { get; set; }

        [AoMember(3)]
        public int Unknown3 { get; set; }

        [AoMember(4)]
        public int Unknown4 { get; set; }

        [AoMember(5)]
        public int Unknown5 { get; set; }

        [AoMember(6)]
        public int Unknown6 { get; set; }

        [AoMember(7)]
        public byte Unknown7 { get; set; }

        #endregion
    }
}