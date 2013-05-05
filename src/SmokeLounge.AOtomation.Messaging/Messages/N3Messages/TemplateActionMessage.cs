// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateActionMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TemplateActionMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.TemplateAction)]
    public class TemplateActionMessage : N3Message
    {
        #region Constructors and Destructors

        public TemplateActionMessage()
        {
            this.N3MessageType = N3MessageType.TemplateAction;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public int ItemLowId { get; set; }

        [AoMember(1)]
        public int ItemHighId { get; set; }

        [AoMember(2)]
        public int Quality { get; set; }

        [AoMember(3)]
        public int Unknown1 { get; set; }

        [AoMember(4)]
        public int Unknown2 { get; set; }

        [AoMember(5)]
        public Identity Placement { get; set; }

        [AoMember(6)]
        public int Unknown3 { get; set; }

        [AoMember(7)]
        public int Unknown4 { get; set; }

        #endregion
    }
}