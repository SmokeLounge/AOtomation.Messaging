using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.Bank)]
    public class BankMessage : N3Message
    {
        public BankMessage()
        {
            this.N3MessageType = N3MessageType.Bank;
        }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        [AoMember(1)]
        public int Unknown2 { get; set; }

        [AoMember(2)]
        public int Unknown3 { get; set; }

        [AoMember(3, SerializeSize = ArraySizeType.X3F1)]
        public BankSlot[] BankSlots { get; set; }
    }
}
