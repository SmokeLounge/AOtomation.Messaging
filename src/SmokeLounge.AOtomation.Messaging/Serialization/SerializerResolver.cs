// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerResolver.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SerializerResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    public class SerializerResolver
    {
        #region Fields

        private readonly SerializerResolverBuilder serializerResolverBuilder;

        #endregion

        #region Constructors and Destructors

        public SerializerResolver(SerializerResolverBuilder serializerResolverBuilder)
        {
            this.serializerResolverBuilder = serializerResolverBuilder;
        }

        #endregion

        #region Public Methods and Operators

        public void Add(Type type, ISerializer serializer)
        {
            throw new NotImplementedException();
        }

        public ISerializer GetSerializer(Type type)
        {
            return this.serializerResolverBuilder.GetSerializer(type);
        }

        #endregion
    }
}