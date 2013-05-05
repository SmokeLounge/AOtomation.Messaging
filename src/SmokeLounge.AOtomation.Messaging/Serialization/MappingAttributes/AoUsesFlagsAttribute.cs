// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AoUsesFlagsAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AoUsesFlagsAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class AoUsesFlagsAttribute : Attribute
    {
        #region Fields

        private readonly FlagsCriteria criteria;

        private readonly int criteriaValue;

        private readonly int[] criteriaValues;

        private readonly string flag;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public AoUsesFlagsAttribute(string flag, Type type, FlagsCriteria criteria, params int[] criteriaValues)
        {
            this.flag = flag;
            this.type = type;
            this.criteria = criteria;
            this.criteriaValues = criteriaValues;

            foreach (var value in criteriaValues)
            {
                this.criteriaValue |= value;
            }
        }

        #endregion

        #region Public Properties

        public FlagsCriteria Criteria
        {
            get
            {
                return this.criteria;
            }
        }

        public int CriteriaValue
        {
            get
            {
                return this.criteriaValue;
            }
        }

        public int[] CriteriaValues
        {
            get
            {
                return this.criteriaValues;
            }
        }

        public string Flag
        {
            get
            {
                return this.flag;
            }
        }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion
    }
}