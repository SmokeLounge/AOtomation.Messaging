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

        private readonly int[] criteriaValues;

        private readonly string flag;

        private readonly Type onFail;

        private readonly Type onMatch;

        #endregion

        #region Constructors and Destructors

        public AoUsesFlagsAttribute(string flag, Type onMatch, Type onFail, FlagsCriteria criteria, params int[] criteriaValues)
        {
            this.flag = flag;
            this.onMatch = onMatch;
            this.onFail = onFail;
            this.criteria = criteria;
            this.criteriaValues = criteriaValues;
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

        public Type OnFail
        {
            get
            {
                return this.onFail;
            }
        }

        public Type OnMatch
        {
            get
            {
                return this.onMatch;
            }
        }

        #endregion
    }
}