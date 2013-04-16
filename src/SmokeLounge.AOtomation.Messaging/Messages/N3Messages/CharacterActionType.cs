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
        CastNano = 19, 

        InfoRequest = 105, 

        Logout = 120, 

        StopLogout = 121, 

        StartSneak = 163, 

        UseItemOnItem = 81, 

        ChangeVisualFlag = 166, 

        TradeskillSourceChanged = 0xDC, 

        TradeskillTargetChanged = 0xDD, 

        TradeskillBuildPressed = 0xDE
    }
}