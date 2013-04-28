using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.KnuBotAppendText)]
    public class KnuBotAppendTextMessage : N3Message
    {
        public KnuBotAppendTextMessage()
        {
            this.N3MessageType = N3MessageType.KnuBotAppendText;
        }

        [AoMember(0)]
        public short Unknown1 { get; set; }

        [AoMember(1)]
        public Identity Target { get; set; }

        [AoMember(2)]
        public int Unknown2 { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.Int32)]
        public string Text { get; set; }

        [AoMember(4)]
        public int Unknown3 { get; set; }
    }
}
