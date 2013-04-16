// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Identity.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Identity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class Identity
    {
        #region Constructors and Destructors

        static Identity()
        {
            None = new Identity { IdentityType = IdentityType.None, Instance = 0 };
        }

        #endregion

        #region Public Properties

        public static Identity None { get; private set; }

        [AoMember(0)]
        public IdentityType IdentityType { get; set; }

        [AoMember(1)]
        public int Instance { get; set; }

        #endregion
    }
}