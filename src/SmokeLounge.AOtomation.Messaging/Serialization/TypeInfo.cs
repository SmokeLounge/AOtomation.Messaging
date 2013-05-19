// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeInfo.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TypeInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class TypeInfo
    {
        #region Fields

        private readonly Dictionary<int, TypeInfo> subTypes;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public TypeInfo(Type type)
        {
            this.type = type;
            this.subTypes = new Dictionary<int, TypeInfo>();

            var knownTypes =
                this.type.GetCustomAttributes(typeof(AoKnownTypeAttribute), false)
                    .Cast<AoKnownTypeAttribute>()
                    .FirstOrDefault();
            if (knownTypes != null)
            {
                this.KnownType = new KnownType(knownTypes.Offset, knownTypes.IdentifierType);
            }

            this.InitializeSubTypes();
        }

        #endregion

        #region Public Properties

        public KnownType KnownType { get; set; }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public TypeInfo GetSubType(int identifier)
        {
            TypeInfo typeInfo;
            this.subTypes.TryGetValue(identifier, out typeInfo);
            return typeInfo;
        }

        #endregion

        #region Methods

        private void InitializeSubTypes()
        {
            this.subTypes.Clear();
            var types = this.type.Assembly.GetTypes().Where(t => t.BaseType == this.type);
            foreach (var subType in types)
            {
                var contract =
                    subType.GetCustomAttributes(typeof(AoContractAttribute), false)
                           .Cast<AoContractAttribute>()
                           .FirstOrDefault();
                if (contract == null)
                {
                    continue;
                }

                var typeInfo = new TypeInfo(subType);
                this.subTypes.Add(contract.Identifier, typeInfo);
            }
        }

        #endregion
    }
}