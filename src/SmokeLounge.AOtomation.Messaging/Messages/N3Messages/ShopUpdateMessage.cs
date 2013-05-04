// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopUpdateMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ShopUpdateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization.Mapping;

    [AoContract((int)N3MessageType.ShopUpdate)]
    public class ShopUpdateMessage : N3Message
    {
        #region Constructors and Destructors

        public ShopUpdateMessage()
        {
            this.N3MessageType = N3MessageType.ShopUpdate;
        }

        #endregion

        #region Public Properties

        [AoMember(0, SerializeSize = ArraySizeType.X3F1)]
        public VendingMachineSlot[] VendingMachineSlots { get; set; }

        #endregion
    }
}