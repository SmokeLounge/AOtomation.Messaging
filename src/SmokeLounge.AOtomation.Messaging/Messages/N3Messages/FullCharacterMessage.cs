// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FullCharacterMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the FullCharacterMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.FullCharacter)]
    public class FullCharacterMessage : N3Message
    {
        #region Constructors and Destructors

        public FullCharacterMessage()
        {
            this.N3MessageType = N3MessageType.FullCharacter;
            this.Unknown = 0x00;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(1, SerializeSize = ArraySizeType.X3F1)]
        public InventorySlot[] InventorySlots { get; set; }

        [AoMember(2, SerializeSize = ArraySizeType.X3F1)]
        public int[] UploadedNanoIds { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown2 { get; set; }

        [AoMember(4)]
        public int Unknown3 { get; set; }

        [AoMember(5)]
        public int Unknown4 { get; set; }

        [AoMember(6)]
        public int Unknown5 { get; set; }

        [AoMember(7)]
        public int Unknown6 { get; set; }

        [AoMember(8)]
        public int Unknown7 { get; set; }

        [AoMember(9)]
        public int Unknown8 { get; set; }

        [AoMember(10, SerializeSize = ArraySizeType.X3F1)]
        public GameTuple<int, uint>[] Stats1 { get; set; }

        [AoMember(11, SerializeSize = ArraySizeType.X3F1)]
        public GameTuple<int, uint>[] Stats2 { get; set; }

        [AoMember(12, SerializeSize = ArraySizeType.X3F1)]
        public GameTuple<byte, byte>[] Stats3 { get; set; }

        [AoMember(13, SerializeSize = ArraySizeType.X3F1)]
        public GameTuple<byte, short>[] Stats4 { get; set; }

        [AoMember(14)]
        public int Unknown9 { get; set; }

        [AoMember(15)]
        public int Unknown10 { get; set; }

        [AoMember(16, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown11 { get; set; }

        [AoMember(17, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown12 { get; set; }

        [AoMember(18, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown13 { get; set; }

        #endregion
    }
}