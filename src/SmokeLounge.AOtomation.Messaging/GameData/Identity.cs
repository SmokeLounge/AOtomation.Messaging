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
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public struct Identity
    {
        #region Static Fields

        public static readonly Identity None = new Identity { Type = IdentityType.None, Instance = 0 };

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public IdentityType Type { get; set; }

        [AoMember(1)]
        public int Instance { get; set; }

        #endregion

        #region Public Methods and Operators

        public static bool operator ==(Identity identity1, Identity identity2)
        {
            return identity1.Equals(identity2);
        }

        public static bool operator !=(Identity identity1, Identity identity2)
        {
            return identity1.Equals(identity2) == false;
        }

        public override bool Equals(object obj)
        {
            return (obj is Identity) && this.Type.Equals(((Identity)obj).Type)
                   && this.Instance.Equals(((Identity)obj).Instance);
        }

        public override int GetHashCode()
        {
            var hashCode = 17;
            hashCode = (23 * hashCode) + this.Type.GetHashCode();
            hashCode = (23 * hashCode) + this.Instance.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}