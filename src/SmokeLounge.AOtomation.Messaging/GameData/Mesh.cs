// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mesh.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Mesh type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class Mesh
    {
        #region Public Properties

        [AoMember(1)]
        public uint Id { get; set; }

        [AoMember(3)]
        public byte Layer { get; set; }

        [AoMember(2)]
        public int OverrideTextureId { get; set; }

        [AoMember(0)]
        public byte Position { get; set; }

        #endregion
    }
}