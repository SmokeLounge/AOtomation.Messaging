// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfoPacketTests.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InfoPacketTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Tests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Messages.N3Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [TestClass]
    public class InfoPacketTests
    {
        #region Public Methods and Operators

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #1 - 0x40")]
        public void Deserialize0x40Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #1 - 0x40");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (CharacterInfoPacket)infoPacketMessage.Info;

            Assert.IsNull(infoPacket.OrganizationId);
            Assert.IsNull(infoPacket.OrganizationRank);
            Assert.IsNull(infoPacket.TowerFields);
            Assert.IsNull(infoPacket.Towers);
            Assert.AreEqual(0, infoPacket.CityPlayfieldId);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #2 - 0x41")]
        public void Deserialize0x41Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #2 - 0x41");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (CharacterInfoPacket)infoPacketMessage.Info;

            Assert.IsNotNull(infoPacket.OrganizationId);
            Assert.IsNotNull(infoPacket.OrganizationRank);
            Assert.IsNull(infoPacket.TowerFields);
            Assert.IsNull(infoPacket.Towers);
            Assert.AreNotEqual(0, infoPacket.CityPlayfieldId);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #3 - 0x43")]
        public void Deserialize0x43Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #3 - 0x43");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (CharacterInfoPacket)infoPacketMessage.Info;

            Assert.IsNotNull(infoPacket.OrganizationId);
            Assert.IsNotNull(infoPacket.OrganizationRank);
            Assert.IsNotNull(infoPacket.TowerFields);
            Assert.IsNull(infoPacket.Towers);
            Assert.AreNotEqual(0, infoPacket.CityPlayfieldId);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #4 - 0x47")]
        public void Deserialize0x47Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #4 - 0x47");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (CharacterInfoPacket)infoPacketMessage.Info;

            Assert.IsNotNull(infoPacket.OrganizationId);
            Assert.IsNotNull(infoPacket.OrganizationRank);
            Assert.IsNotNull(infoPacket.TowerFields);
            Assert.IsNotNull(infoPacket.Towers);
            Assert.AreNotEqual(0, infoPacket.CityPlayfieldId);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #5 - 0x54")]
        public void Deserialize0x54Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #5 - 0x54");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (TowerInfoPacket)infoPacketMessage.Info;

            Assert.IsNull(infoPacket.Timer);
            Assert.IsNull(infoPacket.Unknown13);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #6 - 0x57")]
        public void Deserialize0x57Test()
        {
            var packet = this.ReadTestPacket("InfoPacket #6 - 0x57");

            var messageSerialzer = new MessageSerializer();
            var actual = this.Deserialize(messageSerialzer, packet);
            var infoPacketMessage = (InfoPacketMessage)actual.Body;
            var infoPacket = (TowerInfoPacket)infoPacketMessage.Info;

            Assert.IsNotNull(infoPacket.Timer);
            Assert.IsNotNull(infoPacket.Unknown13);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #1 - 0x40")]
        public void Roundtrip0x40Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #1 - 0x40");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #2 - 0x41")]
        public void Roundtrip0x41Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #2 - 0x41");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #3 - 0x43")]
        public void Roundtrip0x43Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #3 - 0x43");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #4 - 0x47")]
        public void Roundtrip0x47Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #4 - 0x47");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #5 - 0x54")]
        public void Roundtrip0x54Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #5 - 0x54");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(".\\TestData\\InfoPacket #6 - 0x57")]
        public void Roundtrip0x57Test()
        {
            var expected = this.ReadTestPacket("InfoPacket #6 - 0x57");

            var messageSerializer = new MessageSerializer();
            var deserialized = this.Deserialize(messageSerializer, expected);
            var actual = this.Serialize(messageSerializer, deserialized);

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Methods

        private Message Deserialize(MessageSerializer messageSerializer, byte[] packet)
        {
            using (var memoryStream = new MemoryStream(packet))
            {
                var actual = messageSerializer.Deserialize(memoryStream);
                return actual;
            }
        }

        private byte[] ReadTestPacket(string path)
        {
            BinaryReader binaryReader = null;

            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    binaryReader = new BinaryReader(fileStream);
                    var packet = binaryReader.ReadBytes((int)fileStream.Length);
                    binaryReader = null;
                    return packet;
                }
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Dispose();
                }
            }
        }

        private byte[] Serialize(MessageSerializer messageSerializer, Message message)
        {
            using (var memoryStream = new MemoryStream())
            {
                messageSerializer.Serialize(memoryStream, message);
                return memoryStream.ToArray();
            }
        }

        #endregion
    }
}