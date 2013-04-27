// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgClientCommand.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OrgClientCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages.N3Messages
{
    public enum OrgClientCommand : byte
    {
        None = 0, 

        Create = 1, 

        Ranks = 2, 

        Contract = 3, 

        Unknown1 = 4, 

        Info = 5, 

        Disband = 6, 

        StartVote = 7, 

        VoteInfo = 8, 

        Vote = 9, 

        Promote = 10, 

        Demote = 11, 

        Unknown2 = 12, 

        Kick = 13, 

        Invite = 14, 

        Join = 15, 

        Leave = 16, 

        Tax = 17, 

        Bank = 18, 

        BankAdd = 19, 

        BankRemove = 20, 

        BankPaymembers = 21, 

        Debt = 22, 

        History = 23, 

        Objective = 24, 

        Description = 25, 

        Name = 26, 

        GoverningForm = 27, 

        StopVote = 28
    }
}