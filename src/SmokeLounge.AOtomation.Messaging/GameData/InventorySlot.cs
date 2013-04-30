// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventorySlot.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InventorySlot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class InventorySlot
    {
        #region AoMember Properties

        [AoMember(0)]
        public int Placement { get; set; }

        [AoMember(1)]
        public short Flags { get; set; }

        [AoMember(2)]
        public short Count { get; set; }

        [AoMember(3)]
        public Identity Identity { get; set; }

        [AoMember(4)]
        public int ItemLowId { get; set; }

        [AoMember(5)]
        public int ItemHighId { get; set; }

        [AoMember(6)]
        public int Quality { get; set; }

        [AoMember(7)]
        public int Unknown { get; set; }

        #endregion
    }
}