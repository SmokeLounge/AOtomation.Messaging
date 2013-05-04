// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TextMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)PacketType.TextMessage)]
    public class TextMessage : MessageBody
    {
        #region Public Properties

        [AoMember(4)]
        public ChatMessage Message { get; set; }

        public override PacketType PacketType
        {
            get
            {
                return PacketType.TextMessage;
            }
        }

        [AoMember(0)]
        public TextMessageRange Range { get; set; }

        [AoMember(1)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        [AoMember(3)]
        public int Unknown3 { get; set; }

        #endregion
    }
}