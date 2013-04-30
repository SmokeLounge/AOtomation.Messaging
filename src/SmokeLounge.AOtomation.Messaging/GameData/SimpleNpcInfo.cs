// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleNpcInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SimpleNpcInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class SimpleNpcInfo : SimpleCharacterInfo
    {
        #region AoMember Properties

        [AoMember(0)]
        public short Family { get; set; }

        [AoMember(1)]
        public short LosHeight { get; set; }

        #endregion
    }
}