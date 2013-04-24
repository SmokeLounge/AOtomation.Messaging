// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatValue.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StatValue type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class StatValue
    {
        #region Public Properties

        [AoMember(0)]
        public CharacterStat Stat { get; set; }

        [AoMember(1)]
        public uint Value { get; set; }

        #endregion
    }
}