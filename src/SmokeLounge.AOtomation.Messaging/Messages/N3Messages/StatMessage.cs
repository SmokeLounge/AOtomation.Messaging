// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StatMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.Stat)]
    public class StatMessage : N3Message
    {
        #region Constructors and Destructors

        public StatMessage()
        {
            this.N3MessageType = N3MessageType.Stat;
            this.Unknown = 1;
        }

        #endregion

        #region Public Properties

        [AoMember(1)]
        public CharacterStat Stat { get; set; }

        [AoMember(0)]
        public int Unknown { get; set; }

        [AoMember(2)]
        public uint Value { get; set; }

        #endregion
    }
}