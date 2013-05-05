// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomNameRequestMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RandomNameRequestMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)SystemMessageType.RandomNameRequest)]
    public class RandomNameRequestMessage : SystemMessage
    {
        #region Constructors and Destructors

        public RandomNameRequestMessage()
        {
            this.SystemMessageType = SystemMessageType.RandomNameRequest;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public Profession Profession { get; set; }

        #endregion
    }
}