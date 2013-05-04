// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnuBotAnswerMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the KnuBotAnswerMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)N3MessageType.KnuBotAnswer)]
    public class KnuBotAnswerMessage : N3Message
    {
        #region Constructors and Destructors

        public KnuBotAnswerMessage()
        {
            this.N3MessageType = N3MessageType.KnuBotAnswer;
        }

        #endregion

        #region Public Properties

        [AoMember(2)]
        public int Answer { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(0)]
        public short Unknown1 { get; set; }

        #endregion
    }
}