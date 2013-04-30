// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharDCMoveMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharDCMoveMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.CharDCMove)]
    public class CharDCMoveMessage : N3Message
    {
        #region Constructors and Destructors

        public CharDCMoveMessage()
        {
            this.N3MessageType = N3MessageType.CharDCMove;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public byte MoveType { get; set; }

        [AoMember(1)]
        public Quaternion Heading { get; set; }

        [AoMember(2)]
        public Vector3 Coordinates { get; set; }

        [AoMember(3)]
        public int Unknown1 { get; set; }

        [AoMember(4)]
        public int Unknown2 { get; set; }

        [AoMember(5)]
        public int Unknown3 { get; set; }

        #endregion
    }
}