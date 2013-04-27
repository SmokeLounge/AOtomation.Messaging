// --------------------------------------------------------------------------------------------------------------------
// <copyright file="N3TeleportMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the N3TeleportMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.N3Teleport)]
    public class N3TeleportMessage : N3Message
    {
        #region Constructors and Destructors

        public N3TeleportMessage()
        {
            this.N3MessageType = N3MessageType.N3Teleport;
        }

        #endregion

        #region Public Properties

        [AoMember(6)]
        public Identity ChangePlayfield { get; set; }

        [AoMember(0)]
        public Vector3 Destination { get; set; }

        [AoMember(4)]
        public int GameServerId { get; set; }

        [AoMember(1)]
        public Quaternion Heading { get; set; }

        [AoMember(3)]
        public Identity Playfield { get; set; }

        [AoMember(9)]
        public Identity Playfield2 { get; set; }

        [AoMember(5)]
        public int SgId { get; set; }

        [AoMember(2)]
        public byte Unknown1 { get; set; }

        [AoMember(7)]
        public int Unknown4 { get; set; }

        [AoMember(8)]
        public int Unknown5 { get; set; }

        [AoMember(10)]
        public int Unknown6 { get; set; }

        [AoMember(11)]
        public int Unknown7 { get; set; }

        [AoMember(12)]
        public int Unknown8 { get; set; }

        #endregion
    }
}