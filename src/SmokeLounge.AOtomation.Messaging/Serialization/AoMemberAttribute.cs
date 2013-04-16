// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AoMemberAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AoMemberAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AoMemberAttribute : Attribute
    {
        #region Fields

        private readonly int order;

        #endregion

        #region Constructors and Destructors

        public AoMemberAttribute(int order)
        {
            this.order = order;
        }

        #endregion

        #region Public Properties

        public int FixedSizeLength { get; set; }

        public bool IsFixedSize { get; set; }

        public int Order
        {
            get
            {
                return this.order;
            }
        }

        public int PadAfter { get; set; }

        public int PadBefore { get; set; }

        public ArraySizeType SerializeSize { get; set; }

        #endregion
    }
}