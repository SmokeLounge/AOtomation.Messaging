// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgInfoMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgInfoMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages.OrgServerMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((byte)OrgServerMessageType.OrgInfo)]
    public class OrgInfoMessage : OrgServerMessage
    {
        #region Constructors and Destructors

        public OrgInfoMessage()
        {
            this.OrgServerMessageType = OrgServerMessageType.OrgInfo;
        }

        #endregion

        #region Public Properties

        [AoMember(0, SerializeSize = ArraySizeType.Int16)]
        public string Description { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.Int16)]
        public string GoverningForm { get; set; }

        [AoMember(2, SerializeSize = ArraySizeType.Int16)]
        public string History { get; set; }

        [AoMember(4, SerializeSize = ArraySizeType.Int16)]
        public string LeaderName { get; set; }

        [AoMember(1, SerializeSize = ArraySizeType.Int16)]
        public string Objective { get; set; }

        [AoMember(5, SerializeSize = ArraySizeType.Int16)]
        public string Rank { get; set; }

        [AoMember(6, SerializeSize = ArraySizeType.X3F1)]
        public object[] Unknown3 { get; set; }

        #endregion
    }
}