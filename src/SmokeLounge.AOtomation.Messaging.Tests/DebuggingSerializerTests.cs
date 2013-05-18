// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebuggingSerializerTests.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DebuggingSerializerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Tests
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Messages.SystemMessages;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    using StreamReader = SmokeLounge.AOtomation.Messaging.Serialization.StreamReader;
    using StreamWriter = SmokeLounge.AOtomation.Messaging.Serialization.StreamWriter;

    [TestClass]
    public class DebuggingSerializerTests
    {
        #region Public Methods and Operators

        [TestMethod]
        public void CharacterListMessageTest()
        {
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

            var actual = (CharacterListMessage)this.SerializeDeserialize(expected);

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

        #endregion

        #region Methods

        private object SerializeDeserialize(object obj)
        {
            MemoryStream memoryStream = null;

            var serializerResolver = new DebuggingSerializerBuilderResolver<MessageBody>().Build();
            var serializer = serializerResolver.GetSerializer(obj.GetType());

            try
            {
                memoryStream = new MemoryStream();
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var streamReader = new StreamReader(memoryStream))
                {
                    var serializationContext = new SerializationContext(serializerResolver);
                    serializer.Serialize(streamWriter, serializationContext, obj);
                    var arr = memoryStream.ToArray();
                    Console.WriteLine(BitConverter.ToString(arr));

                    memoryStream.Position = 0;
                    var deserializationContext = new SerializationContext(serializerResolver);
                    var result = serializer.Deserialize(streamReader, deserializationContext);
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