// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayfieldVendorInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayfieldVendorInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class PlayfieldVendorInfo
    {
        #region Constructors and Destructors

        public PlayfieldVendorInfo()
        {
            this.Unknown1 = new Identity { Type = IdentityType.VendingMachine, Instance = 1 };
            this.Unknown2 = 0x00000001;
        }

        #endregion

        #region Public Properties

        [AoMember(2)]
        public int FirstVendorId { get; set; }

        [AoMember(0)]
        public Identity Unknown1 { get; set; }

        [AoMember(1)]
        public int Unknown2 { get; set; }

        [AoMember(3)]
        public int VendorCount { get; set; }

        #endregion
    }
}