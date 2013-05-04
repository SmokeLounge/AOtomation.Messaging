// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AoFlagsAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AoFlagsAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AoFlagsAttribute : Attribute
    {
        #region Fields

        private readonly string flag;

        #endregion

        #region Constructors and Destructors

        public AoFlagsAttribute(string flag)
        {
            this.flag = flag;
        }

        #endregion

        #region Public Properties

        public string Flag
        {
            get
            {
                return this.flag;
            }
        }

        #endregion
    }
}