// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTimeMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the GameTimeMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.GameTime)]
    public class GameTimeMessage : N3Message
    {
        #region Constructors and Destructors

        public GameTimeMessage()
        {
            this.N3MessageType = N3MessageType.GameTime;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public float Unknown1 { get; set; }

        [AoMember(1)]
        public int Unknown2 { get; set; }

        [AoMember(2)]
        public int Unknown3 { get; set; }

        [AoMember(3)]
        public float Unknown4 { get; set; }

        #endregion
    }
}