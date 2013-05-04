// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponItemFullUpdateMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the WeaponItemFullUpdateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.WeaponItemFullUpdate)]
    public class WeaponItemFullUpdateMessage : N3Message
    {
        #region Constructors and Destructors

        public WeaponItemFullUpdateMessage()
        {
            this.N3MessageType = N3MessageType.WeaponItemFullUpdate;
        }

        #endregion

        #region Public Properties

        [AoMember(11)]
        public int AcgItemLevel { get; set; }

        [AoMember(13)]
        public int AcgItemTemplateId { get; set; }

        [AoMember(15)]
        public int AcgItemTemplateId2 { get; set; }

        [AoMember(20)]
        public int Ammo { get; set; }

        [AoMember(18)]
        public int Amount { get; set; }

        [AoMember(1)]
        public Identity Character { get; set; }

        [AoMember(19)]
        public int Energy { get; set; }

        [AoMember(7)]
        public int Flags { get; set; }

        [AoMember(8)]
        public uint ItemFlags { get; set; }

        [AoMember(17)]
        public int MultipleCount { get; set; }

        [AoMember(12)]
        public int QualityLevel { get; set; }

        [AoMember(9)]
        public int StaticInstance { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        [AoMember(3)]
        public int Unknown3 { get; set; }

        [AoMember(4)]
        public short Unknown4 { get; set; }

        [AoMember(5)]
        public int Unknown5 { get; set; }

        [AoMember(6)]
        public int Unknown6 { get; set; }

        [AoMember(21)]
        public int Unknown7 { get; set; }

        [AoMember(16)]
        public int WeaponItemHighId { get; set; }

        [AoMember(10)]
        public int WeaponItemId { get; set; }

        [AoMember(14)]
        public int WeaponItemLowId { get; set; }

        #endregion
    }
}