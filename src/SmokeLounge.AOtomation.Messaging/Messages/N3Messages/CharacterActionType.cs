// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterActionType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharacterActionType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    public enum CharacterActionType
    {
        CastNano = 0x00000013, 

        UseItemOnItem = 0x00000051, 

        Unknown2 = 0x00000062, 

        InfoRequest = 0x00000069, 

        Unknown1 = 0x0000006B, 

        Logout = 0x00000078, 

        StopLogout = 0x00000079, 

        StartedSneaking = 0x000000A2, 

        StartSneak = 0x000000A3, 

        ChangeVisualFlag = 0x000000A6, 

        ChangeAnimationAndStance = 0x000000A7, 

        TradeskillSourceChanged = 0x000000DC, 

        TradeskillTargetChanged = 0x000000DD, 

        TradeskillBuildPressed = 0x000000DE, 
    }
}