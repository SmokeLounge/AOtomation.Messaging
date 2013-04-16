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

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Reflection;

    public class PropertyMeta
    {
        #region Fields

        private readonly AoMemberAttribute memberAttribute;

        private readonly SerializationOptions options;

        private readonly PropertyInfo propertyInfo;

        #endregion

        #region Constructors and Destructors

        public PropertyMeta(PropertyInfo propertyInfo, AoMemberAttribute memberAttribute)
        {
            this.propertyInfo = propertyInfo;
            this.memberAttribute = memberAttribute;
            this.options = new SerializationOptions(
                this.memberAttribute.IsFixedSize, 
                this.memberAttribute.FixedSizeLength, 
                this.memberAttribute.SerializeSize, 
                this.memberAttribute.PadAfter, 
                this.memberAttribute.PadBefore);
        }

        #endregion

        #region Public Properties

        public SerializationOptions Options
        {
            get
            {
                return this.options;
            }
        }

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