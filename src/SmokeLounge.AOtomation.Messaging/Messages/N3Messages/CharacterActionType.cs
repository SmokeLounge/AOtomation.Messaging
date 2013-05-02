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
        TeamRequest = 0x0000001A, 

        CastNano = 0x00000013, 

        TeamRequestReply = 0x00000015, 

        LeaveTeam = 0x00000020, 

        AcceptTeamRequest = 0x00000023, 

        UseItemOnItem = 0x00000051, 

        StandUp = 0x00000057,

        Unknown3 = 0x00000061, 

        Unknown2 = 0x00000062, 

        InfoRequest = 0x00000069, 

        Unknown1 = 0x0000006B, 

        DeleteItem = 0x00000070, 

        Logout = 0x00000078, 

        StopLogout = 0x0000007A, 

        Equip = 0x00000083, 

        StartedSneaking = 0x000000A2, 

        StartSneak = 0x000000A3, 

        ChangeVisualFlag = 0x000000A6, 

        ChangeAnimationAndStance = 0x000000A7, 

        UploadNano = 0x000000CC, 

        TradeskillSourceChanged = 0x000000DC, 

        TradeskillTargetChanged = 0x000000DD, 

        TradeskillBuildPressed = 0x000000DE, 

        TradeskillSource = 0x000000DF, 

        TradeskillTarget = 0x000000E0, 

        TradeskillNotValid = 0x000000E1, 

        TradeskillOutOfRange = 0x000000E2, 

        TradeskillRequirement = 0x000000E3, 

        TradeskillResult = 0x000000E4
    }
}