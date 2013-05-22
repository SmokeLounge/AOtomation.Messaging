// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DiagnosticInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System.Collections.Generic;

    public class DiagnosticInfo
    {
        #region Fields

        private readonly List<DiagnosticInfo> diagnosticInfos;

        #endregion

        #region Constructors and Destructors

        public DiagnosticInfo()
        {
            this.diagnosticInfos = new List<DiagnosticInfo>();
        }

        #endregion

        #region Public Properties

        public IEnumerable<DiagnosticInfo> DiagnosticInfos
        {
            get
            {
                return this.diagnosticInfos;
            }
        }

        public long Length { get; set; }

        public long Offset { get; set; }

        public PropertyMetaData PropertyMetaData { get; set; }

        public object Value { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Add(DiagnosticInfo diagnosticInfo)
        {
            this.diagnosticInfos.Add(diagnosticInfo);
        }

        #endregion
    }
}