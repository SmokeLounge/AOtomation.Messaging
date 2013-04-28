// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VendingMachineSlot.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the VendingMachineSlot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class VendingMachineSlot
    {
        #region Public Properties

        [AoMember(1)]
        public int ItemHighId { get; set; }

        [AoMember(0)]
        public int ItemLowId { get; set; }

        [AoMember(2)]
        public int Quality { get; set; }

        #endregion
    }
}