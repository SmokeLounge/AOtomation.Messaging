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

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    public enum SystemMessageType
    {
        LoginError = 0x0000000D, 

        CharacterList = 0x0000000E, 

        CreateCharacter = 0x0000000F, 

        NameInUse = 0x00000010, 

        CharacterCreated = 0x00000011, 

        DeleteCharacter = 0x00000014, 

        CharacterDeleted = 0x00000015, 

        SelectCharacter = 0x00000016, 

        ZoneInfo = 0x00000017, 

        ZoneLogin = 0x0000001B, 

        UserLogin = 0x00000022, 

        ServerSalt = 0x00000024, 

        UserCredentials = 0x00000025, 

        ZoneRedirection = 0x0000003C, 

        ChatServerInfo = 0x00000043, 

        RandomNameRequest = 0x00000055, 

        SuggestName = 0x00000056
    }
}