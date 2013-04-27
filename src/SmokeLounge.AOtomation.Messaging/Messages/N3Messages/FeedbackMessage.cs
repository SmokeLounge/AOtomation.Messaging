// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the FeedbackMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract((int)N3MessageType.Feedback)]
    public class FeedbackMessage : N3Message
    {
        #region Constructors and Destructors

        public FeedbackMessage()
        {
            this.N3MessageType = N3MessageType.Feedback;
        }

        #endregion

        #region Public Properties

        [AoMember(1)]
        public int CategoryId { get; set; }

        [AoMember(2)]
        public int MessageId { get; set; }

        [AoMember(0)]
        public int Unknown1 { get; set; }

        #endregion
    }
}