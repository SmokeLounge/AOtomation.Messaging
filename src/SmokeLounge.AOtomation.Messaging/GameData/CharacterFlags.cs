// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterFlags.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharacterFlags type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using System;

    [Flags]
    public enum CharacterFlags
    {
        // 0000 0000 0000 0000 0000 0000 0000 0000
        None = 0x00000000, 

        // 0000 0000 0100 0000 0000 0000 0000 0000
        HasVisibleName = 0x00400000
    }
}