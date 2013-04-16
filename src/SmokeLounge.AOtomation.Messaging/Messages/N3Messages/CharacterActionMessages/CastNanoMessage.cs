// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CastNanoMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CastNanoMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages.CharacterActionMessages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)CharacterActionType.CastNano)]
    public class CastNanoMessage : CharacterActionMessage
    {
        #region Constructors and Destructors

        public CastNanoMessage()
        {
            this.CharacterActionType = CharacterActionType.CastNano;
        }

        #endregion

        #region Public Properties

        [AoMember(3)]
        public int NanoId { get; set; }

        [AoMember(1)]
        public Identity TargetId { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        #endregion
    }
}