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
        #region Public Properties

        public long Length { get; set; }

        public long Offset { get; set; }

        public PropertyMetaData PropertyMetaData { get; set; }

        public object Value { get; set; }

        #endregion
    }
}