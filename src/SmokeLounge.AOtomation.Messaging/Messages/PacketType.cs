// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    public enum PacketType : short
    {
        SystemMessage = 0x0001, 

        TextMessage = 0x0005, 

        N3Message = 0x000A, 

        PingMessage = 0x000B, 

        OperatorMessage = 0x000E, 

        InitiateCompressionMessage = 0x7F00
    }
}