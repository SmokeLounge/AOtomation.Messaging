// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationOptions.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SerializationOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System.Collections.Generic;

    public class SerializationOptions
    {
        #region Fields

        private readonly IDictionary<string, int> flags;

        #endregion

        #region Constructors and Destructors

        public SerializationOptions()
        {
            this.flags = new Dictionary<string, int>();
        }

        #endregion

        #region Public Methods and Operators

        public int GetFlagValue(string flag)
        {
            int value;
            this.flags.TryGetValue(flag, out value);
            return value;
        }

        public void SetFlagValue(string flag, int value)
        {
            this.flags[flag] = value;
        }

        #endregion
    }
}