using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.KnuBotAnswerList)]
    public class KnuBotAnswerListMessage : N3Message
    {
        public KnuBotAnswerListMessage()
        {
            this.N3MessageType = N3MessageType.KnuBotAnswerList;
        }

        [AoMember(0)]
        public short Unknown1 { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(2, SerializeSize = ArraySizeType.Int32)]
        public KnuBotDialogOption[] DialogOptions { get; set; }
    }
}
