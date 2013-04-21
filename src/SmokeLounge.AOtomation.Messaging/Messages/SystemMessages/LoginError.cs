// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginError.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the LoginError type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    public enum LoginError
    {
        AlreadyLoggedIn = 0x00000014, 

        InvalidUserNamePassword = 0x0000006A, 

        PlayerBannedOrNotPaid = 0x0000006C
    }
}