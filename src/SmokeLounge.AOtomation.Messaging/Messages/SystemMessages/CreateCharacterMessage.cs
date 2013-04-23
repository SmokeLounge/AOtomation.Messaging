// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCharacterMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CreateCharacterMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)SystemMessageType.CreateCharacter)]
    public class CreateCharacterMessage : SystemMessage
    {
        #region Constructors and Destructors

        public CreateCharacterMessage()
        {
            this.SystemMessageType = SystemMessageType.CreateCharacter;
        }

        #endregion

        #region Public Properties

        [AoMember(6, SerializeSize = ArraySizeType.Int32)]
        public string AreaName { get; set; }

        [AoMember(2)]
        public Breed Breed { get; set; }

        [AoMember(11)]
        public Fatness Fatness { get; set; }

        [AoMember(3)]
        public Gender Gender { get; set; }

        [AoMember(9)]
        public int HeadMesh { get; set; }

        [AoMember(5)]
        public int Level { get; set; }

        [AoMember(10)]
        public int MonsterScale { get; set; }

        [AoMember(1, SerializeSize = ArraySizeType.Int32)]
        public string Name { get; set; }

        [AoMember(4)]
        public Profession Profession { get; set; }

        [AoMember(12)]
        public StarterArea StarterArea { get; set; }

        [AoMember(0, IsFixedSize = true, FixedSizeLength = 49)]
        public byte[] Unknown1 { get; set; }

        [AoMember(7)]
        public int Unknown2 { get; set; }

        [AoMember(8)]
        public int Unknown3 { get; set; }

        #endregion
    }
}