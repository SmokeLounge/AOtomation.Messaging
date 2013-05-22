// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Probe.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Probe type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    public class Probe
    {
        #region Fields

        private readonly DiagnosticInfo diagnosticInfo;

        private readonly Probe parent;

        #endregion

        #region Constructors and Destructors

        public Probe(Probe parent = null)
        {
            this.parent = parent;
            this.diagnosticInfo = new DiagnosticInfo();
        }

        #endregion

        #region Public Properties

        public DiagnosticInfo DiagnosticInfo
        {
            get
            {
                return this.diagnosticInfo;
            }
        }

        public Probe Parent
        {
            get
            {
                return this.parent;
            }
        }

        #endregion
    }
}