// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgInviteMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgInviteMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages.OrgServerMessages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((byte)OrgServerMessageType.OrgInvite)]
    public class OrgInviteMessage : OrgServerMessage
    {
        #region Constructors and Destructors

        public OrgInviteMessage()
        {
            this.OrgServerMessageType = OrgServerMessageType.OrgInvite;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public int Unknown3 { get; set; }

        #endregion
    }
}