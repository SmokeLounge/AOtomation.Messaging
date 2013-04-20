// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPAddressSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IPAddressSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization.Serializers
{
    using System;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;

    public class IPAddressSerializer : ISerializer
    {
        #region Fields

        private readonly ConstructorInfo constructor;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public IPAddressSerializer()
        {
            this.type = typeof(IPAddress);
            this.constructor = this.type.GetConstructor(new[] { typeof(byte[]) });
            this.Serializer = this.SerializerImp;
            this.Deserializer = this.DeserializerImp;
        }

        #endregion

        #region Public Properties

        public Func<StreamReader, SerializationOptions, object> Deserializer { get; private set; }

        public Action<StreamWriter, SerializationOptions, object> Serializer { get; private set; }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        public Expression DeserializerExpression(
            ParameterExpression streamReaderExpression, 
            ConstantExpression optionsExpression, 
            Expression assignmentTargetExpression)
        {
            var readMethodInfo = ReflectionHelper.GetMethodInfo<StreamReader, Func<int, byte[]>>(o => o.ReadBytes);
            var callReadExp = Expression.Call(
                streamReaderExpression, readMethodInfo, new Expression[] { Expression.Constant(4) });

            var createInstance = Expression.New(this.constructor, new Expression[] { callReadExp });

            if (assignmentTargetExpression.Type.IsAssignableFrom(this.type))
            {
                return Expression.Assign(assignmentTargetExpression, createInstance);
            }

            var assignmentExp = Expression.Assign(
                assignmentTargetExpression, Expression.Convert(createInstance, assignmentTargetExpression.Type));
            return assignmentExp;
        }

        public Expression SerializerExpression(
            ParameterExpression streamWriterExpression, ConstantExpression optionsExpression, Expression valueExpression)
        {
            var writeMethodInfo = ReflectionHelper.GetMethodInfo<StreamWriter, Action<byte[]>>(o => o.WriteBytes);
            var mapToIPv4MethodInfo = ReflectionHelper.GetMethodInfo<IPAddress, Func<IPAddress>>(o => o.MapToIPv4);
            var getAddressBytesMethodInfo =
                ReflectionHelper.GetMethodInfo<IPAddress, Func<byte[]>>(o => o.GetAddressBytes);

            var mapToIPv4Exp = Expression.Call(valueExpression, mapToIPv4MethodInfo);
            var callGetAddressBytesExp = Expression.Call(mapToIPv4Exp, getAddressBytesMethodInfo);

            var callWriteExp = Expression.Call(
                streamWriterExpression, writeMethodInfo, new Expression[] { callGetAddressBytesExp });
            return callWriteExp;
        }

        #endregion

        #region Methods

        private object DeserializerImp(StreamReader reader, SerializationOptions options)
        {
            var address = new IPAddress(reader.ReadBytes(4));
            return address;
        }

        private void SerializerImp(StreamWriter writer, SerializationOptions options, object value)
        {
            var address = (IPAddress)value;
            writer.WriteBytes(address.MapToIPv4().GetAddressBytes());
        }

        #endregion
    }
}