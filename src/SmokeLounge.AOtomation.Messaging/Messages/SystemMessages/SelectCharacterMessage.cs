// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectCharacterMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SelectCharacterMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.SelectCharacter)]
    public class SelectCharacterMessage : SystemMessage
    {
        #region Constructors and Destructors

        public SelectCharacterMessage()
        {
            this.SystemMessageType = SystemMessageType.SelectCharacter;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public int CharacterId { get; set; }

        #endregion
    }
}