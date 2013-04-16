// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBody.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageBody type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoKnownType(2, IdentifierType.Int16)]
    public abstract class MessageBody
    {
        #region Public Properties

        public abstract PacketType PacketType { get; }

        #endregion
    }
}