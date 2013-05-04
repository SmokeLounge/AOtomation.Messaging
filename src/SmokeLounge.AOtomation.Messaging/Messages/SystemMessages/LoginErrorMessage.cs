// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginErrorMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the LoginErrorMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)SystemMessageType.LoginError)]
    public class LoginErrorMessage : SystemMessage
    {
        #region Constructors and Destructors

        public LoginErrorMessage()
        {
            this.SystemMessageType = SystemMessageType.LoginError;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public LoginError Error { get; set; }

        #endregion
    }
}