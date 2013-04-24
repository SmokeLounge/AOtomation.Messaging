// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialAttackWeaponMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SpecialAttackWeaponMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.SpecialAttackWeapon)]
    internal class SpecialAttackWeaponMessage : N3Message
    {
        #region Constructors and Destructors

        public SpecialAttackWeaponMessage()
        {
            this.N3MessageType = N3MessageType.SpecialAttackWeapon;
            this.Unknown = 0x00;
            this.Unknown1 = 0x00000007;
            this.Unknown2 = 0x00000007;
            this.Unknown3 = 0x00000007;
            this.Unknown4 = 0x0000000E;
            this.Unknown5 = 0x00000064;
        }

        #endregion

        #region Public Properties

        [AoMember(0, SerializeSize = ArraySizeType.X3F1)]
        public SpecialAttackInfo[] Specials { get; set; }

        [AoMember(1)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        [AoMember(3)]
        public int Unknown3 { get; set; }

        [AoMember(4)]
        public int Unknown4 { get; set; }

        [AoMember(5)]
        public int Unknown5 { get; set; }

        #endregion
    }
}