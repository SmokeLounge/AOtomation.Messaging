// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceUpdateMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AppearanceUpdateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    [AoContract((int)N3MessageType.AppearanceUpdate)]
    public class AppearanceUpdateMessage : N3Message
    {
        #region Constructors and Destructors

        public AppearanceUpdateMessage()
        {
            this.N3MessageType = N3MessageType.AppearanceUpdate;
        }

        #endregion

        #region AoMember Properties

        [AoMember(0, SerializeSize = ArraySizeType.X3F1)]
        public Texture[] Textures { get; set; }

        [AoMember(1, SerializeSize = ArraySizeType.X3F1)]
        public Mesh[] Meshes { get; set; }

        [AoMember(2)]
        public short VisualFlags { get; set; }

        [AoMember(3)]
        public byte Unknown1 { get; set; }

        #endregion
    }
}