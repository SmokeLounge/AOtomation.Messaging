// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VendingMachineFullUpdateMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the VendingMachineFullUpdateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)N3MessageType.VendingMachineFullUpdate)]
    public class VendingMachineFullUpdateMessage : N3Message
    {
        #region Constructors and Destructors

        public VendingMachineFullUpdateMessage()
        {
            this.N3MessageType = N3MessageType.VendingMachineFullUpdate;
        }

        #endregion

        #region Public Properties

        [AoMember(3)]
        public Vector3 Coordinates { get; set; }

        [AoMember(4)]
        public Quaternion Heading { get; set; }

        [AoMember(5)]
        public int PlayfieldId { get; set; }

        [AoMember(15)]
        public int TemplateId { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(12)]
        public byte Unknown10 { get; set; }

        [AoMember(13)]
        public short Unknown11 { get; set; }

        [AoMember(14)]
        public int Unknown12 { get; set; }

        [AoMember(16)]
        public int Unknown13 { get; set; }

        [AoMember(17)]
        public int Unknown14 { get; set; }

        [AoMember(18)]
        public int Unknown15 { get; set; }

        [AoMember(19)]
        public int Unknown16 { get; set; }

        [AoMember(20)]
        public int Unknown17 { get; set; }

        [AoMember(21)]
        public int Unknown18 { get; set; }

        [AoMember(22)]
        public int Unknown19 { get; set; }

        [AoMember(1)]
        public int Unknown2 { get; set; }

        [AoMember(23)]
        public int Unknown20 { get; set; }

        [AoMember(24)]
        public int Unknown21 { get; set; }

        [AoMember(25)]
        public int Unknown22 { get; set; }

        [AoMember(26)]
        public int Unknown23 { get; set; }

        [AoMember(27)]
        public int Unknown24 { get; set; }

        [AoMember(28)]
        public int Unknown25 { get; set; }

        [AoMember(29)]
        public int Unknown26 { get; set; }

        [AoMember(30)]
        public int Unknown27 { get; set; }

        [AoMember(31, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown28 { get; set; }

        [AoMember(32)]
        public int Unknown29 { get; set; }

        [AoMember(2)]
        public int Unknown3 { get; set; }

        [AoMember(6)]
        public int Unknown4 { get; set; }

        [AoMember(7)]
        public int Unknown5 { get; set; }

        [AoMember(8)]
        public short Unknown6 { get; set; }

        [AoMember(9)]
        public int Unknown7 { get; set; }

        [AoMember(10)]
        public int Unknown8 { get; set; }

        [AoMember(11)]
        public byte Unknown9 { get; set; }

        #endregion
    }
}