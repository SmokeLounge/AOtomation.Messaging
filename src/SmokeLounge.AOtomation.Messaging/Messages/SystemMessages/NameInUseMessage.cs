// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameInUseMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NameInUseMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.SystemMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)SystemMessageType.NameInUse)]
    public class NameInUseMessage : SystemMessage
    {
        #region Constructors and Destructors

        public NameInUseMessage()
        {
            this.SystemMessageType = SystemMessageType.NameInUse;
            this.Unknown = 0x0000001E;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public int Unknown { get; set; }

        #endregion
    }
}