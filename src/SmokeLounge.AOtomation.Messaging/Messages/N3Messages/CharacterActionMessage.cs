// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterActionMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharacterActionMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.CharacterAction)]
    public class CharacterActionMessage : N3Message
    {
        #region Constructors and Destructors

        public CharacterActionMessage()
        {
            this.N3MessageType = N3MessageType.CharacterAction;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public CharacterActionType Action { get; set; }

        [AoMember(1)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public Identity Target { get; set; }

        [AoMember(3)]
        public int Parameter1 { get; set; }

        [AoMember(4)]
        public int Parameter2 { get; set; }

        [AoMember(5)]
        public short Unknown2 { get; set; }

        #endregion
    }
}