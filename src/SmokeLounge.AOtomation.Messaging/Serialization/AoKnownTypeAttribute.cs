// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AoKnownTypeAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AoKnownTypeAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AoKnownTypeAttribute : Attribute
    {
        #region Fields

        private readonly IdentifierType identifierType;

        private readonly int offset;

        #endregion

        #region Constructors and Destructors

        public AoKnownTypeAttribute(int offset, IdentifierType identifierType)
        {
            this.offset = offset;
            this.identifierType = identifierType;
        }

        #endregion

        #region Public Properties

        public IdentifierType IdentifierType
        {
            get
            {
                return this.identifierType;
            }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
        }

        #endregion
    }
}