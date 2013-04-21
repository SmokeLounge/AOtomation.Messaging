// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginCharacterInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the LoginCharacterInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class LoginCharacterInfo
    {
        #region Constructors and Destructors

        public LoginCharacterInfo()
        {
            this.Unknown1 = 4;
            this.Unknown2 = 1;
        }

        #endregion

        #region Public Properties

        [AoMember(16, SerializeSize = ArraySizeType.Int32)]
        public string AreaName { get; set; }

        [AoMember(12)]
        public Breed Breed { get; set; }

        [AoMember(9)]
        public int CharacterId { get; set; }

        [AoMember(8)]
        public int CharacterInfoVersion { get; set; }

        [AoMember(5)]
        public int ExitDoor { get; set; }

        [AoMember(6)]
        public Identity ExitDoorId { get; set; }

        [AoMember(13)]
        public Gender Gender { get; set; }

        [AoMember(1)]
        public int Id { get; set; }

        [AoMember(15)]
        public int Level { get; set; }

        [AoMember(11, SerializeSize = ArraySizeType.Int32)]
        public string Name { get; set; }

        [AoMember(4)]
        public int PlayfieldAttribute { get; set; }

        [AoMember(3)]
        public Identity PlayfieldId { get; set; }

        [AoMember(2)]
        public byte PlayfieldProxyVersion { get; set; }

        [AoMember(14)]
        public Profession Profession { get; set; }

        [AoMember(22)]
        public CharacterStatus Status { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(7)]
        public int Unknown2 { get; set; }

        [AoMember(10)]
        public int Unknown3 { get; set; }

        [AoMember(17)]
        public int Unknown4 { get; set; }

        [AoMember(18)]
        public int Unknown5 { get; set; }

        [AoMember(19)]
        public int Unknown6 { get; set; }

        [AoMember(20)]
        public int Unknown7 { get; set; }

        [AoMember(21)]
        public int Unknown8 { get; set; }

        #endregion
    }
}