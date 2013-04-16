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
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.CharacterAction)]
    [AoKnownType(29, IdentifierType.Int32)]
    public abstract class CharacterActionMessage : N3Message
    {
        #region Constructors and Destructors

        protected CharacterActionMessage()
        {
            this.N3MessageType = N3MessageType.CharacterAction;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public CharacterActionType CharacterActionType { get; set; }

        #endregion
    }
}