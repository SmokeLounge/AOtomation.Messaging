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
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages.OrgServerMessages;
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
        public void CharacterActionMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new CharacterActionMessage
                               {
                                   Identity =
                                       new Identity
                                           {
                                               Type = IdentityType.CanbeAffected, 
                                               Instance = 12345
                                           }, 
                                   Target = new Identity { Type = IdentityType.None }, 
                                   Parameter1 = 0, 
                                   Parameter2 = 12345
                               };

            var serializer = context.GetSerializer(expected.GetType());

            var actual = (CharacterActionMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertN3Message(expected, actual);
            this.AssertCharacterActionMessage(expected, actual);

            Assert.AreEqual(expected.Target.Type, actual.Target.Type);
            Assert.AreEqual(expected.Target.Instance, actual.Target.Instance);
            Assert.AreEqual(expected.Unknown1, actual.Unknown1);
            Assert.AreEqual(expected.Parameter1, actual.Parameter1);
            Assert.AreEqual(expected.Parameter2, actual.Parameter2);
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
        public void OrgInviteMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new OrgInviteMessage
                               {
                                   Identity =
                                       new Identity
                                           {
                                               Type = IdentityType.CanbeAffected, 
                                               Instance = 12345
                                           }, 
                                   Organization =
                                       new Identity
                                           {
                                               Type = IdentityType.Organization, 
                                               Instance = 67890
                                           }, 
                                   OrganizationName = "Trollipopz"
                               };

            var serializer = context.GetSerializer(expected.GetType());

            var actual = (OrgInviteMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertN3Message(expected, actual);
            this.AssertOrgServerMessage(expected, actual);
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
        public void StatMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new StatMessage
                               {
                                   Identity = Identity.None, 
                                   Stats =
                                       new[]
                                           {
                                               new GameTuple<CharacterStat, uint>
                                                   {
                                                       Value1 =
                                                           CharacterStat
                                                           .ACGEntranceStyles, 
                                                       Value2 = 1
                                                   }, 
                                               new GameTuple<CharacterStat, uint>
                                                   {
                                                       Value1 =
                                                           CharacterStat
                                                           .BackMesh, 
                                                       Value2 = 3
                                                   }, 
                                               new GameTuple<CharacterStat, uint>
                                                   {
                                                       Value1 =
                                                           CharacterStat
                                                           .CATAnim, 
                                                       Value2 = 5
                                                   }
                                           }
                               };

            var serializer = context.GetSerializer(expected.GetType());
            var actual = (StatMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertN3Message(expected, actual);

            var expectedChars = expected.Stats.GetEnumerator();
            var actualChars = actual.Stats.GetEnumerator();

            while (expectedChars.MoveNext())
            {
                actualChars.MoveNext();
                var expectedChar = (GameTuple<CharacterStat, uint>)expectedChars.Current;
                var actualChar = (GameTuple<CharacterStat, uint>)actualChars.Current;

                Assert.AreEqual(expectedChar.Value1, actualChar.Value1);
                Assert.AreEqual(expectedChar.Value2, actualChar.Value2);
            }
        }

        [TestMethod]
        public void ZoneRedirectionMessageTest()
        {
            var context = new SerializationContextBuilder<MessageBody>().Build();

            var expected = new ZoneInfoMessage
                               {
                                   CharacterId = 1234567890, 
                                   ServerIpAddress = IPAddress.Loopback, 
                                   ServerPort = 45678
                               };

            var serializer = context.GetSerializer(expected.GetType());
            var actual = (ZoneInfoMessage)this.SerializeDeserialize(serializer, expected);

            this.AssertSystemMessage(expected, actual);
            Assert.AreEqual(expected.CharacterId, actual.CharacterId);
            Assert.AreEqual(expected.ServerIpAddress, actual.ServerIpAddress);
            Assert.AreEqual(expected.ServerPort, actual.ServerPort);
        }

        #endregion

        #region Methods

        private void AssertCharacterActionMessage(CharacterActionMessage expected, CharacterActionMessage actual)
        {
            Assert.AreEqual(expected.Action, actual.Action);
        }

        private void AssertN3Message(N3Message expected, N3Message actual)
        {
            Assert.AreEqual(expected.Identity.Type, actual.Identity.Type);
            Assert.AreEqual(expected.Identity.Instance, actual.Identity.Instance);
            Assert.AreEqual(expected.N3MessageType, actual.N3MessageType);
            Assert.AreEqual(expected.PacketType, actual.PacketType);
            Assert.AreEqual(expected.Unknown, actual.Unknown);
        }

        private void AssertOrgServerMessage(OrgServerMessage expected, OrgServerMessage actual)
        {
            Assert.AreEqual(expected.OrgServerMessageType, actual.OrgServerMessageType);
            Assert.AreEqual(expected.Unknown1, actual.Unknown1);
            Assert.AreEqual(expected.Unknown2, actual.Unknown2);
            Assert.AreEqual(expected.Organization.Type, actual.Organization.Type);
            Assert.AreEqual(expected.Organization.Instance, actual.Organization.Instance);
            Assert.AreEqual(expected.OrganizationName, actual.OrganizationName);
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