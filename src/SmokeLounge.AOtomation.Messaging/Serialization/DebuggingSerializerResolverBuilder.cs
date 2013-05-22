// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebuggingSerializerResolverBuilder.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DebuggingSerializerResolverBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;

    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;

    public class DebuggingSerializerResolverBuilder<T> : SerializerResolverBuilder<T>
    {
        #region Methods

        internal override ISerializer GetSerializer(Type type)
        {
            var serializer = base.GetSerializer(type);
            var debuggingSerializer = new DiagnosticSerializer(serializer);
            return debuggingSerializer;
        }

        #endregion
    }
}