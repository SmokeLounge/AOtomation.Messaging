// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberOptions.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MemberOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class MemberOptions
    {
        #region Fields

        private readonly int fixedSizeLength;

        private readonly bool isFixedSize;

        private readonly int padAfter;

        private readonly int padBefore;

        private readonly ArraySizeType serializeSize;

        private readonly Type type;

        private readonly AoUsesFlagsAttribute[] usesFlagsAttributes;

        #endregion

        #region Constructors and Destructors

        public MemberOptions(
            Type type, 
            bool isFixedSize, 
            int fixedSizeLength, 
            ArraySizeType serializeSize, 
            int padAfter, 
            int padBefore, 
            AoUsesFlagsAttribute[] usesFlagsAttributes)
        {
            this.type = type;
            this.isFixedSize = isFixedSize;
            this.fixedSizeLength = fixedSizeLength;
            this.serializeSize = serializeSize;
            this.padAfter = padAfter;
            this.padBefore = padBefore;
            this.usesFlagsAttributes = usesFlagsAttributes;
        }

        #endregion

        #region Public Properties

        public int FixedSizeLength
        {
            get
            {
                return this.fixedSizeLength;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return this.isFixedSize;
            }
        }

        public int PadAfter
        {
            get
            {
                return this.padAfter;
            }
        }

        public int PadBefore
        {
            get
            {
                return this.padBefore;
            }
        }

        public ArraySizeType SerializeSize
        {
            get
            {
                return this.serializeSize;
            }
        }

        public Type Type
        {
            get
            {
                return this.type;
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