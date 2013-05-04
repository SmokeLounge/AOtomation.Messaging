// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericCmdMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the GenericCmdMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)N3MessageType.GenericCmd)]
    public class GenericCmdMessage : N3Message
    {
        #region Constructors and Destructors

        public GenericCmdMessage()
        {
            this.N3MessageType = N3MessageType.GenericCmd;
        }

        #endregion

        #region Public Properties

        [AoMember(2)]
        public GenericCmdAction Action { get; set; }

        [AoMember(1)]
        public int Count { get; set; }

        [AoMember(5)]
        public Identity Target { get; set; }

        [AoMember(0)]
        public int Temp1 { get; set; }

        [AoMember(3)]
        public int Temp4 { get; set; }

        [AoMember(4)]
        public Identity User { get; set; }

        #endregion
    }
}