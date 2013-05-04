// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgServerMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgServerMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.OrgServer)]
    [AoKnownType(26, IdentifierType.Byte)]
    public abstract class OrgServerMessage : N3Message
    {
        #region Constructors and Destructors

        protected OrgServerMessage()
        {
            this.N3MessageType = N3MessageType.OrgServer;
        }

        #endregion

        #region Public Properties

        [AoMember(0)]
        public OrgServerMessageType OrgServerMessageType { get; set; }

        [AoMember(3)]
        public Identity Organization { get; set; }

        [AoMember(4, SerializeSize = ArraySizeType.Int16)]
        public string OrganizationName { get; set; }

        [AoMember(1)]
        public int Unknown1 { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        #endregion
    }
}