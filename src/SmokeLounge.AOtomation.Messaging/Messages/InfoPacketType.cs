// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfoPacketType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InfoPacketType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    public enum InfoPacketType : byte
    {
        Character = 0x40, // 0100 0000

        CharacterOrg = 0x41, // 0100 0001

        CharacterOrgSite = 0x43, // 0100 0011

        CharacterOrgSiteTower = 0x47, // 0100 0111

        Monster = 0x50, // 0101 0000

        Tower = 0x54, // 0101 0100

        ControlTower = 0x5C // 0101 1100
    }
}