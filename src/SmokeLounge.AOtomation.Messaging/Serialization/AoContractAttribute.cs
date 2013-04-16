// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AoContractAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AoContractAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AoContractAttribute : Attribute
    {
        #region Fields

        private readonly int identifier;

        #endregion

        #region Constructors and Destructors

        public AoContractAttribute(int identifier)
        {
            this.identifier = identifier;
        }

        #endregion

        #region Public Properties

        public int Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        #endregion
    }
}