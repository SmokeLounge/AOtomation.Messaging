// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMetaData.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PropertyMetaData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Reflection;

    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class PropertyMetaData
    {
        #region Fields

        private readonly AoFlagsAttribute flagsAttribute;

        private readonly MemberOptions options;

        private readonly PropertyInfo propertyInfo;

        private readonly AoUsesFlagsAttribute[] usesFlagsAttributes;

        #endregion

        #region Constructors and Destructors

        public PropertyMetaData(
            PropertyInfo propertyInfo, 
            AoMemberAttribute memberAttribute, 
            AoFlagsAttribute flagsAttribute, 
            AoUsesFlagsAttribute[] usesFlagsAttributes)
        {
            this.propertyInfo = propertyInfo;
            this.flagsAttribute = flagsAttribute;
            this.usesFlagsAttributes = usesFlagsAttributes;
            this.options = new MemberOptions(
                this.propertyInfo.PropertyType, 
                memberAttribute.IsFixedSize, 
                memberAttribute.FixedSizeLength, 
                memberAttribute.SerializeSize, 
                memberAttribute.PadAfter, 
                memberAttribute.PadBefore, 
                usesFlagsAttributes);
        }

        #endregion

        #region Public Properties

        public AoFlagsAttribute FlagsAttribute
        {
            get
            {
                return this.flagsAttribute;
            }
        }

        public MemberOptions Options
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

        public AoUsesFlagsAttribute[] UsesFlagsAttributes
        {
            get
            {
                return this.usesFlagsAttributes;
            }
        }

        #endregion
    }
}