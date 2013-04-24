// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMetaBuilderTest.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TypeMetaBuilderTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Tests
{
    using System;
    using System.IO;
    using System.Net;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages.CharacterActionMessages;
    using SmokeLounge.AOtomation.Messaging.Messages.SystemMessages;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOtomation.Messaging.Serialization.Serializers;

    using StreamReader = SmokeLounge.AOtomation.Messaging.Serialization.StreamReader;
    using StreamWriter = SmokeLounge.AOtomation.Messaging.Serialization.StreamWriter;

    [TestClass]
    public class TypeMetaBuilderTest
    {
        #region Public Methods and Operators

        [TestMethod]
        public void CastNanoMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new CastNanoMessage
                               {
                                   NanoId = 12345, 
                                   Identity =
                                       new Identity
                                           {
                                               IdentityType = IdentityType.CanbeAffected, 
                                               Instance = 12345
                                           }, 
                                   TargetId = new Identity { IdentityType = IdentityType.None }
                               };

            var serializer = context.GetSerializer(expected.GetType());

            var actual = (CastNanoMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertN3Message(expected, actual);
            this.AssertCharacterActionMessage(expected, actual);

            Assert.AreEqual(expected.NanoId, actual.NanoId);
            Assert.AreEqual(expected.TargetId.IdentityType, actual.TargetId.IdentityType);
            Assert.AreEqual(expected.TargetId.Instance, actual.TargetId.Instance);
            Assert.AreEqual(expected.Unknown1, actual.Unknown1);
            Assert.AreEqual(expected.Unknown2, actual.Unknown2);
        }

        [TestMethod]
        public void CharacterListMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new CharacterListMessage
                               {
                                   Characters =
                                       new[]
                                           {
                                               new LoginCharacterInfo
                                                   {
                                                       Name = "Trolololo", 
                                                       AreaName = "ICC", 
                                                       PlayfieldId = Identity.None, 
                                                       ExitDoorId = Identity.None
                                                   }, 
                                               new LoginCharacterInfo
                                                   {
                                                       Name = "Haiguise", 
                                                       AreaName = "Bore", 
                                                       PlayfieldId = Identity.None, 
                                                       ExitDoorId = Identity.None
                                                   }
                                           }
                               };

            var serializer = context.GetSerializer(expected.GetType());
            var actual = (CharacterListMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertSystemMessage(expected, actual);
            Assert.AreEqual(expected.AllowedCharacters, actual.AllowedCharacters);
            Assert.AreEqual(expected.Characters.Length, actual.Characters.Length);

            var expectedChars = expected.Characters.GetEnumerator();
            var actualChars = actual.Characters.GetEnumerator();

            while (expectedChars.MoveNext())
            {
                actualChars.MoveNext();
                var expectedChar = (LoginCharacterInfo)expectedChars.Current;
                var actualChar = (LoginCharacterInfo)actualChars.Current;

                Assert.AreEqual(expectedChar.AreaName, actualChar.AreaName);
                Assert.AreEqual(expectedChar.Name, actualChar.Name);
            }

            Assert.AreEqual(expected.Expansions, actual.Expansions);
        }

        [TestMethod]
        public void PlayfieldAnarchyFMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new PlayfieldAnarchyFMessage
                               {
                                   Identity = Identity.None,
                                   CharacterCoordinates = new Vector3(),
                                   PlayfieldId1 = Identity.None,
                                   PlayfieldId2 = Identity.None, 
                                   PlayfieldX = 1, 
                                   PlayfieldZ = 2
                               };

            var serializer = context.GetSerializer(expected.GetType());

            var actual = (PlayfieldAnarchyFMessage)this.SerializeDeserialize(serializer, expected);

            Assert.AreEqual(expected.PlayfieldX, actual.PlayfieldX);
            Assert.AreEqual(expected.PlayfieldZ, actual.PlayfieldZ);
        }

        [TestMethod]
        public void PlayfieldAnarchyFMessageWithVendorTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new PlayfieldAnarchyFMessage
                               {
                                   Identity = Identity.None,
                                   CharacterCoordinates = new Vector3(),
                                   PlayfieldId1 = Identity.None,
                                   PlayfieldId2 = Identity.None, 
                                   PlayfieldVendorInfo = new PlayfieldVendorInfo(), 
                                   PlayfieldX = 1, 
                                   PlayfieldZ = 2
                               };

            var serializer = context.GetSerializer(expected.GetType());

            var actual = (PlayfieldAnarchyFMessage)this.SerializeDeserialize(serializer, expected);

            Assert.AreEqual(expected.PlayfieldX, actual.PlayfieldX);
            Assert.AreEqual(expected.PlayfieldZ, actual.PlayfieldZ);
        }

        [TestMethod]
        public void ZoneRedirectionMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new ZoneRedirectionMessage
                               {
                                   CharacterId = 1234567890, 
                                   ServerIpAddress = IPAddress.Loopback, 
                                   ServerPort = 45678
                               };

            var serializer = context.GetSerializer(expected.GetType());
            var actual = (ZoneRedirectionMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertSystemMessage(expected, actual);
            Assert.AreEqual(expected.CharacterId, actual.CharacterId);
            Assert.AreEqual(expected.ServerIpAddress, actual.ServerIpAddress);
            Assert.AreEqual(expected.ServerPort, actual.ServerPort);
        }

        #endregion

        #region Methods

        private void AssertCharacterActionMessage(CharacterActionMessage expected, CharacterActionMessage actual)
        {
            Assert.AreEqual(expected.CharacterActionType, actual.CharacterActionType);
        }

        private void AssertN3Message(N3Message expected, N3Message actual)
        {
            Assert.AreEqual(expected.Identity.IdentityType, actual.Identity.IdentityType);
            Assert.AreEqual(expected.Identity.Instance, actual.Identity.Instance);
            Assert.AreEqual(expected.N3MessageType, actual.N3MessageType);
            Assert.AreEqual(expected.PacketType, actual.PacketType);
            Assert.AreEqual(expected.Unknown, actual.Unknown);
        }

        private void AssertSystemMessage(SystemMessage expected, SystemMessage actual)
        {
            Assert.AreEqual(expected.PacketType, actual.PacketType);
            Assert.AreEqual(expected.SystemMessageType, actual.SystemMessageType);
        }

        private object SerializeDeserialize(ISerializer serializer, object obj)
        {
            MemoryStream memoryStream = null;

            try
            {
                memoryStream = new MemoryStream();
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var streamReader = new StreamReader(memoryStream))
                {
                    serializer.Serializer(streamWriter, null, obj);
                    var arr = memoryStream.ToArray();
                    Console.WriteLine(BitConverter.ToString(arr));

                    memoryStream.Position = 0;
                    var result = serializer.Deserializer(streamReader, null);
                    memoryStream = null;
                    return result;
                }
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        #endregion
    }
}