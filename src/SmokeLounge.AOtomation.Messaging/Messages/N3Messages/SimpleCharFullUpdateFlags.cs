// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleCharFullUpdateFlags.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SimpleCharFullUpdateFlags type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using System;

    [Flags]
    public enum SimpleCharFullUpdateFlags
    {
        // 0000 0000 0000 0000 0000 0000 0000 0000
        None = 0x00000000, 

        // 0000 0000 0000 0000 0000 0000 0000 0001
        IsNpc = 0x00000001, 

        // 0000 0000 0000 0000 0000 0000 0010 0000
        HasFightingTarget = 0x00000020, 

        // 0000 0000 0000 0000 0000 0000 0100 0000
        HasPlayfieldId = 0x00000040, 

        // 0000 0000 0000 0000 0000 0000 1000 0000
        HasHeadMesh = 0x00000080, 

        // 0000 0000 0000 0000 0000 0010 0000 0000
        HasHeading = 0x00000200, 

        // 0000 0000 0000 0000 0000 1000 0000 0000
        HasSmallHealth = 0x00000800, 

        // 0000 0000 0000 0000 0001 0000 0000 0000
        HasExtendedLevel = 0x00001000, 

        // 0000 0000 0000 0000 0010 0000 0000 0000
        HasExtendedRunSpeed = 0x00002000, 

        // 0000 0000 0000 0000 0100 0000 0000 0000
        HasSmallHealthDamage = 0x00004000, 

        // 0000 0000 0000 0010 0000 0000 0000 0000
        HasExtendedNpcFamily = 0x00020000, 

        // 0000 0000 0000 1000 0000 0000 0000 0000
        HasExtendedNpcLosHeight = 0x00080000, 

        // 0000 0100 0000 0000 0000 0000 0000 0000
        HasOrgName = 0x04000000, 
    }
}