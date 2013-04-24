// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatServerDetailsMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ChatServerDetailsMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.ChatServerDetails)]
    public class ChatServerDetailsMessage : SystemMessage
    {
        #region Constructors and Destructors

        public ChatServerDetailsMessage()
        {
            this.SystemMessageType = SystemMessageType.ChatServerDetails;
            this.Unknown1 = 1;
        }

        #endregion

        #region Public Properties

        [AoMember(1, SerializeSize = ArraySizeType.Int32)]
        public string HostName { get; set; }

        [AoMember(2)]
        public int Port { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(3)]
        public int Unknown2 { get; set; }

        #endregion
    }
}