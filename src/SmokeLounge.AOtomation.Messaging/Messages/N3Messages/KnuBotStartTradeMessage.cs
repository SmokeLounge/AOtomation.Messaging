// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnuBotStartTradeMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the KnuBotStartTradeMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.KnuBotStartTrade)]
    public class KnuBotStartTradeMessage : N3Message
    {
        #region Constructors and Destructors

        public KnuBotStartTradeMessage()
        {
            this.N3MessageType = N3MessageType.KnuBotStartTrade;
            this.Identity = new Identity();
            this.Target = new Identity();
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public short Unknown1 { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(2)]
        public int NumberOfItemSlotsInTradeWindow { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.Int32)]
        public string Message { get; set; }

        #endregion
    }
}