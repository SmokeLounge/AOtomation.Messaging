// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IdentityType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    public enum IdentityType
    {
        None = 0, 

        Playfield2 = 0x00009C50, 

        CanbeAffected = 0x0000C350, 

        VendingMachine = 0x0000C75B, 

        Playfield1 = 0x0000C79C, 

        Playfield = 0x0000C79D, 
    }
}