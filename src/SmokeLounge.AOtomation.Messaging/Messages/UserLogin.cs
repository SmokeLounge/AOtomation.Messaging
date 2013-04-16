// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="Smoke Lounge">
//   Copyright (c) Smoke Lounge. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserLogin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [AoContract(0x00000022)]
    public class UserLogin : SystemMessage
    {
        #region Constructors and Destructors

        public UserLogin()
        {
            this.Unknown = 2;
        }

        #endregion

        #region Public Properties

        [AoMember(2, IsFixedSize = true, FixedSizeLength = 20)]
        public string ClientVersion { get; set; }

        [AoMember(0)]
        public int Unknown { get; set; }

        [AoMember(1, IsFixedSize = true, FixedSizeLength = 40)]
        public string UserName { get; set; }

        #endregion
    }
}