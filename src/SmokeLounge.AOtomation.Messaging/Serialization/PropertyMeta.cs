// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMeta.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PropertyMeta type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Reflection;

    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    public class PropertyMeta
    {
        #region Fields

        private readonly PropertyInfo propertyInfo;

        #endregion

        #region Constructors and Destructors

        public PropertyMeta(PropertyInfo propertyInfo, AoMemberAttribute memberAttribute)
        {
            this.propertyInfo = propertyInfo;
            this.Options = new MemberOptions(
                memberAttribute.IsFixedSize, 
                memberAttribute.FixedSizeLength, 
                memberAttribute.SerializeSize, 
                memberAttribute.PadAfter, 
                memberAttribute.PadBefore);
        }

        #endregion

        #region Public Properties

        public MemberOptions Options { get; set; }

        public PropertyInfo Property
        {
            get
            {
                return this.propertyInfo;
            }
        }

        public Type Type
        {
            get
            {
                return this.propertyInfo.PropertyType;
            }
        }

        #endregion
    }
}