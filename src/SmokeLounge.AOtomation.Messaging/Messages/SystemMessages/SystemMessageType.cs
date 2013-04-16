// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemMessageType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SystemMessageType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    public enum SystemMessageType
    {
        CharacterList = 0x0000000E, 

        SelectCharacter = 0x00000016, 

        ZoneRedirection = 0x00000017, 

        UserLogin = 0x00000022, 

        ServerSalt = 0x00000024, 

        UserCredentials = 0x00000025
    }
}