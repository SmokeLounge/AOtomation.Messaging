// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Header.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Header type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    public class Header
    {
        #region Public Properties

        public short MessageId { get; set; }

        public PacketType PacketType { get; set; }

        public int Receiver { get; set; }

        public int Sender { get; set; }

        public short Size { get; set; }

        public short Unknown { get; set; }

        #endregion
    }
}