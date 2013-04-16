// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationContext.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SerializationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Collections.Generic;

    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;

    public class SerializationContext
    {
        #region Fields

        private readonly Dictionary<Type, ISerializer> typeSerializers;

        #endregion

        #region Constructors and Destructors

        public SerializationContext(Dictionary<Type, ISerializer> typeSerializers)
        {
            this.typeSerializers = typeSerializers;
        }

        #endregion

        #region Public Methods and Operators

        public void Add(Type type, ISerializer serializer)
        {
            this.typeSerializers[type] = serializer;
        }

        public ISerializer GetSerializer(Type type)
        {
            ISerializer typeSerializer;
            this.typeSerializers.TryGetValue(type, out typeSerializer);
            return typeSerializer;
        }

        #endregion
    }
}