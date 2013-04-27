// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatTextMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ChatTextMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.ChatText)]
    public class ChatTextMessage : N3Message
    {
        #region Constructors and Destructors

        public ChatTextMessage()
        {
            this.N3MessageType = N3MessageType.ChatText;
        }

        #endregion

        #region Public Properties

        [AoMember(0, SerializeSize = ArraySizeType.Int16)]
        public string Text { get; set; }

        [AoMember(1)]
        public short Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        #endregion
    }
}