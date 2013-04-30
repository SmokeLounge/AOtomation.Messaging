// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimplePcInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SimplePcInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class SimplePcInfo : SimpleCharacterInfo
    {
        #region AoMember Properties

        [AoMember(0)]
        public uint CurrentNano { get; set; }

        [AoMember(1)]
        public int Team { get; set; }

        [AoMember(2)]
        public short Swim { get; set; }

        [AoMember(3)]
        public short StrengthBase { get; set; }

        [AoMember(4)]
        public short AgilityBase { get; set; }

        [AoMember(5)]
        public short StaminaBase { get; set; }

        [AoMember(6)]
        public short IntelligenceBase { get; set; }

        [AoMember(7)]
        public short SenseBase { get; set; }

        [AoMember(8)]
        public short PsychicBase { get; set; }

        [AoMember(9, SerializeSize = ArraySizeType.Int16)]
        public string FirstName { get; set; }

        [AoMember(10, SerializeSize = ArraySizeType.Int16)]
        public string LastName { get; set; }

        [AoMember(11, SerializeSize = ArraySizeType.Int16)]
        public string OrgName { get; set; }

        #endregion
    }
}