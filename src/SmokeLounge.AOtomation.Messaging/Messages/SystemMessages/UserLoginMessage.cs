// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLoginMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the UserLoginMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.UserLogin)]
    public class UserLoginMessage : SystemMessage
    {
        #region Constructors and Destructors

        public UserLoginMessage()
        {
            this.SystemMessageType = SystemMessageType.UserLogin;
            this.Unknown = 2;
        }

        #endregion

        #region Public Properties

        [AoMember(2, IsFixedSize = true, FixedSizeLength = 20)]
        public string ClientVersion { get; set; }

        [AoMember(0)]
        public int Unknown { get; set; }

        [AoMember(1, IsFixedSize = true, FixedSizeLength = 40)]
        public string UserName { get; set; }

        #endregion
    }
}