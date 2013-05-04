// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActiveNano.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ActiveNano type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class ActiveNano
    {
        #region Public Properties

        [AoMember(0)]
        public int NanoId { get; set; }

        [AoMember(1)]
        public int NanoInstance { get; set; }

        [AoMember(2)]
        public int Time1 { get; set; }

        [AoMember(3)]
        public int Time2 { get; set; }

        #endregion
    }
}