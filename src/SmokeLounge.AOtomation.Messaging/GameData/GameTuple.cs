// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTuple.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the GameTuple type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class GameTuple<T1, T2>
    {
        #region AoMember Properties

        [AoMember(0)]
        public T1 Value1 { get; set; }

        [AoMember(1)]
        public T2 Value2 { get; set; }

        #endregion
    }
}