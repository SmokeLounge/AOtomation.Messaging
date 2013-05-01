// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamMemberMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TeamMemberMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.TeamMember)]
    public class TeamMemberMessage : N3Message
    {
        #region Constructors and Destructors

        public TeamMemberMessage()
        {
            this.N3MessageType = N3MessageType.TeamMember;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public byte Unknown1 { get; set; }

        [AoMember(1)]
        public short Unknown2 { get; set; }

        [AoMember(2)]
        public Identity Character { get; set; }

        [AoMember(3)]
        public Identity Team { get; set; }

        [AoMember(4)]
        public uint Unknown3 { get; set; }

        [AoMember(5)]
        public int Unknown4 { get; set; }

        [AoMember(6)]
        public short Unknown5 { get; set; }

        [AoMember(7, SerializeSize = ArraySizeType.Int32)]
        public string Name { get; set; }

        [AoMember(8)]
        public short Unknown6 { get; set; }

        #endregion
    }
}