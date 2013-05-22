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
    using System.Linq;

    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class SerializationContext
    {
        #region Fields

        private readonly List<DiagnosticInfo> diagnosticInfos;

        private readonly IDictionary<string, int> flags;

        private readonly SerializerResolver serializerResolver;

        private Probe probe;

        #endregion

        #region Constructors and Destructors

        public SerializationContext(SerializerResolver serializerResolver)
        {
            this.serializerResolver = serializerResolver;
            this.diagnosticInfos = new List<DiagnosticInfo>();
            this.flags = new Dictionary<string, int>();
        }

        #endregion

        #region Public Properties

        public IEnumerable<DiagnosticInfo> DiagnosticInfos
        {
            get
            {
                return this.diagnosticInfos;
            }
        }

        #endregion

        #region Public Methods and Operators

        public Probe BeginProbe()
        {
            this.probe = new Probe(this.probe);
            return this.probe;
        }

        public void EndProbe(Probe probe)
        {
            this.probe = probe.Parent;
            if (this.probe != null)
            {
                this.probe.DiagnosticInfo.Add(probe.DiagnosticInfo);
            }
            else
            {
                this.diagnosticInfos.Add(probe.DiagnosticInfo);
            }
        }

        public AoUsesFlagsAttribute Evaluate(IEnumerable<AoUsesFlagsAttribute> usesFlags)
        {
            return usesFlags.FirstOrDefault(this.Evaluate);
        }

        public int GetFlagValue(string flag)
        {
            int value;
            this.flags.TryGetValue(flag, out value);
            return value;
        }

        public void SetFlagValue(string flag, int value)
        {
            this.flags[flag] = value;
        }

        #endregion

        #region Methods

        internal object Deserialize(StreamReader streamReader, PropertyMetaData propertyMetaData)
        {
            if (propertyMetaData.UsesFlagsAttributes.Any() == false)
            {
                return null;
            }

            var usesFlag = this.Evaluate(propertyMetaData.UsesFlagsAttributes);
            if (usesFlag == null)
            {
                return null;
            }

            var serializer = this.serializerResolver.GetSerializer(usesFlag.Type);
            var value = serializer.Deserialize(streamReader, this, propertyMetaData);

            if (propertyMetaData.Type.IsValueType)
            {
                if (propertyMetaData.Type.IsPrimitive)
                {
                    return Convert.ChangeType(value, propertyMetaData.Type);
                }

                if (propertyMetaData.Type.IsEnum)
                {
                    return Convert.ChangeType(value, Enum.GetUnderlyingType(propertyMetaData.Type));
                }
            }

            return value;
        }

        internal void Serialize(StreamWriter streamWriter, object obj, PropertyMetaData propertyMetaData)
        {
            ISerializer serializer;
            if (propertyMetaData.UsesFlagsAttributes.Any() == false)
            {
                serializer = this.serializerResolver.GetSerializer(obj.GetType());
            }
            else
            {
                var usesFlag = this.Evaluate(propertyMetaData.UsesFlagsAttributes);
                if (usesFlag == null)
                {
                    return;
                }

                serializer = this.serializerResolver.GetSerializer(usesFlag.Type);
            }

            if (propertyMetaData.Type.IsValueType)
            {
                if (propertyMetaData.Type.IsPrimitive || propertyMetaData.Type.IsEnum)
                {
                    obj = Convert.ChangeType(obj, serializer.Type);
                }
            }

            serializer.Serialize(streamWriter, this, obj, propertyMetaData: propertyMetaData);
        }

        private bool Evaluate(AoUsesFlagsAttribute usesFlags)
        {
            switch (usesFlags.Criteria)
            {
                case FlagsCriteria.HasAll:
                    return this.EvaluateHasAll(usesFlags);
                case FlagsCriteria.HasAny:
                    return this.EvaluateHasAny(usesFlags);
                case FlagsCriteria.EqualsToAny:
                    return this.EvaluateEqualsToAny(usesFlags);
                case FlagsCriteria.Default:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool EvaluateEqualsToAny(AoUsesFlagsAttribute usesFlags)
        {
            var flagValue = this.GetFlagValue(usesFlags.Flag);
            return usesFlags.CriteriaValues.Any(v => v == flagValue);
        }

        private bool EvaluateHasAll(AoUsesFlagsAttribute usesFlags)
        {
            var flagValue = this.GetFlagValue(usesFlags.Flag);
            return (flagValue & usesFlags.CriteriaValue) == usesFlags.CriteriaValue;
        }

        private bool EvaluateHasAny(AoUsesFlagsAttribute usesFlags)
        {
            var flagValue = this.GetFlagValue(usesFlags.Flag);
            return (flagValue & usesFlags.CriteriaValue) > 0;
        }

        #endregion
    }
}