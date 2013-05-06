// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TowerField.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TowerField type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class TowerField
    {
        #region AoMember Properties

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(1)]
        public Identity Identity { get; set; }

        [AoMember(2, SerializeSize = ArraySizeType.Int16)]
        public string Name { get; set; }

        [AoMember(3)]
        public int Unknown2 { get; set; }

        [AoMember(4)]
        public int Unknown3 { get; set; }

        #endregion
    }
}