// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NanoEffect.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NanoEffect type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class NanoEffect
    {
        #region AoMember Properties

        [AoMember(0)]
        public Identity Effect { get; set; }

        [AoMember(1)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int CriterionCount { get; set; }

        [AoMember(3)]
        public int Hits { get; set; }

        [AoMember(4)]
        public int Delay { get; set; }

        [AoMember(5)]
        public int Unknown2 { get; set; }

        [AoMember(6)]
        public int Unknown3 { get; set; }

        [AoMember(7)]
        public int GfxValue { get; set; }

        [AoMember(8)]
        public int GfxLife { get; set; }

        [AoMember(9)]
        public int GfxSize { get; set; }

        [AoMember(10)]
        public int GfxRed { get; set; }

        [AoMember(11)]
        public int GfxGreen { get; set; }

        [AoMember(12)]
        public int GfxBlue { get; set; }

        [AoMember(13)]
        public int GfxFade { get; set; }

        #endregion
    }
}