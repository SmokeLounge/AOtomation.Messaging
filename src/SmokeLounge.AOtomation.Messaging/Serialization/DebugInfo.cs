// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DebugInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    public class DebugInfo
    {
        #region Fields

        private readonly long length;

        private readonly long offset;

        private readonly PropertyMetaData propertyMetaData;

        #endregion

        #region Constructors and Destructors

        public DebugInfo(PropertyMetaData propertyMetaData, long offset, long length)
        {
            this.propertyMetaData = propertyMetaData;
            this.offset = offset;
            this.length = length;
        }

        #endregion

        #region Public Properties

        public long Length
        {
            get
            {
                return this.length;
            }
        }

        public long Offset
        {
            get
            {
                return this.offset;
            }
        }

        public PropertyMetaData PropertyMetaData
        {
            get
            {
                return this.propertyMetaData;
            }
        }

        #endregion
    }
}