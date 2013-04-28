using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    public class KnuBotDialogOption
    {
        [AoMember(0, SerializeSize = ArraySizeType.Int32)]
        public string Text { get; set; }
    }
}
