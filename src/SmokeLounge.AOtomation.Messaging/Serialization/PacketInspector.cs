// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketInspector.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketInspector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using SmokeLounge.AOtomation.Messaging.Messages;

    public class PacketInspector
    {
        #region Fields

        private readonly TypeInfo typeInfo;

        #endregion

        #region Constructors and Destructors

        public PacketInspector()
        {
            this.typeInfo = new TypeInfo(typeof(MessageBody));
        }

        #endregion

        #region Public Methods and Operators

        public TypeInfo FindSubType(StreamReader reader)
        {
            var current = this.typeInfo;

            while (current != null)
            {
                if (current.KnownType == null)
                {
                    return current;
                }

                reader.Position = current.KnownType.Offset;
                int identifier;
                switch (current.KnownType.IdentifierType)
                {
                    case IdentifierType.Byte:
                        identifier = reader.ReadByte();
                        break;
                    case IdentifierType.Int16:
                        identifier = reader.ReadInt16();
                        break;
                    case IdentifierType.Int32:
                        identifier = reader.ReadInt32();
                        break;
                    default:
                        return null;
                }

                var subType = current.GetSubType(identifier);
                if (subType == null)
                {
                    return null;
                }

                current = subType;
            }

            return null;
        }

        #endregion
    }
}