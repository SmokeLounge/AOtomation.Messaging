// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetStatMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SetStatMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.SetStat)]
    public class SetStatMessage : N3Message
    {
        #region Constructors and Destructors

        public SetStatMessage(CharacterStat stat, int value)
            : this()
        {
            this.Stat = stat;
            this.Value = value;
        }

        public SetStatMessage()
        {
            this.N3MessageType = N3MessageType.SetStat;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public int Value { get; set; }

        [AoMember(1)]
        public CharacterStat Stat { get; set; }

        #endregion
    }
}