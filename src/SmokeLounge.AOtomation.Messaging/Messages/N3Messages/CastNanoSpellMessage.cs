// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CastNanoSpellMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CastNanoSpellMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)N3MessageType.CastNanoSpell)]
    public class CastNanoSpellMessage : N3Message
    {
        #region Constructors and Destructors

        public CastNanoSpellMessage()
        {
            this.N3MessageType = N3MessageType.CastNanoSpell;
        }

        #endregion

        #region Public Properties

        [AoMember(3)]
        public Identity Caster { get; set; }

        [AoMember(0)]
        public int NanoId { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(2)]
        public int Unknown1 { get; set; }

        #endregion
    }
}