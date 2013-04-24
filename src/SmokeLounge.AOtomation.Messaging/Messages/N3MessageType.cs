// --------------------------------------------------------------------------------------------------------------------
// <copyright file="N3MessageType.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the N3MessageType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Messages
{
    public enum N3MessageType
    {
        KnuBotNpcDescription = 0x000a0c5a, 

        AddTemplate = 0x052e2f0c, 

        GridDestinationSelect = 0x0639474d, 

        WeatherControl = 0x0C5a5d6d, 

        PetToMaster = 0x0d381f02, 

        FlushRdbCaches = 0x1078735a, 

        ShopSearchResult = 0x1330734f, 

        ShopSearchRequest = 0x145a4f66, 

        AcceptBsInvite = 0x166a435e, 

        AddPet = 0x194e4f76, 

        SetPos = 0x195e496e, 

        ReflectAttack = 0x1c3a4f77, 

        SpecialAttackWeapon = 0x1d3c0f1c, 

        MentorInvite = 0x2001377e, 

        Action = 0x2049527c, 

        Script = 0x204f4871, 

        FormatFeedback = 0x206b4b73, 

        KnuBotAnswer = 0x2103247d, 

        Quest = 0x212c487a, 

        MineFullUpdate = 0x215b5678, 

        LookAt = 0x2252445f, 

        ShieldAttack = 0x25192476, 

        CastNanoSpell = 0x25314d6d, 

        ResearchUpdate = 0x253d024c, 

        FollowTarget = 0x260f3671, 

        RelocateDynels = 0x264b514b, 

        Absorb = 0x264e5f61, 

        Reload = 0x26515e61, 

        KnuBotCloseChatWindow = 0x270a4c62, 

        SimpleCharFullUpdate = 0x271b3a6b, 

        StartLogout = 0x28251f01, 

        Attack = 0x28494070, 

        TeamMemberInfo = 0x28784248, 

        FullCharacter = 0x29304349, 

        LaserTargetList = 0x2933154f, 

        TrapDisarmed = 0x2a253f5f, 

        Fov = 0x2a293d0f, 

        Stat = 0x2b333d6e, 

        QueueUpdate = 0x2c2f061c, 

        KnuBotRejectedItems = 0x2d212407, 

        PlayerShopFullUpdate = 0x2e072a78, 

        OrgInfoPacket = 0x2e2a4a6b, 

        N3PlayfieldFullUpdate = 0x30161355, 

        ResearchRequest = 0x3115534d, 

        AreaFormula = 0x3129233b, 

        InfromPlayer = 0x3301337a, 

        Mail = 0x333b2867, 

        ApplySpells = 0x342c1d1d, 

        Bank = 0x343c287f, 

        ShopInventory = 0x353f4f52, 

        TemplateAction = 0x35505644, 

        Trade = 0x36284f6e, 

        DoorFullUpdate = 0x365a5071, 

        CityAdvantages = 0x365e555b, 

        HealthDamage = 0x3710256c, 

        FightModeUpdate = 0x371d0542, 

        SetShopName = 0x373e3513, 

        Buff = 0x39343c68, 

        KnuBotTrade = 0x3a1b2c0c, 

        DropTemplate = 0x3a243f41, 

        GridSelected = 0x3a322a4a, 

        SimpleItemFullUpdate = 0x3b11256f, 

        KnuBotOpenChatWindow = 0x3b132d64, 

        WeaponItemFullUpdate = 0x3b1d2268, 

        SocialActionCmd = 0x3b290771, 

        Raid = 0x3b3b2878, 

        ShadowLevel = 0x3c1e2803, 

        Clone = 0x3c265179, 

        ShopCommission = 0x3d5b4544, 

        ServerPathPosDebugInfo = 0x3d746c7c, 

        Skill = 0x3e205660, 

        LeaveBattle = 0x3f3a1914, 

        ShopInfo = 0x405b4f27, 

        AppearanceUpdate = 0x41624f0d, 

        N3Teleport = 0x43197d22, 

        PerkUpdate = 0x435f7023, 

        SendScore = 0x44483b3a, 

        Resurrect = 0x445f2a0b, 

        UpdateClientVisual = 0x45072a0b, 

        HouseDemolishStart = 0x45273f0a, 

        PlaySound = 0x455d2938, 

        AttackInfo = 0x46002f16, 

        TeamMember = 0x46312d2e, 

        SpawnMech = 0x464d000a, 

        QuestFullUpdate = 0x465a4061, 

        ChestItemFullUpdate = 0x465a5d73, 

        NanoAttack = 0x4727213e, 

        DropDynel = 0x47483633, 

        ContainerAddItem = 0x47537a24, 

        Visibility = 0x49222612, 

        StopFight = 0x4a41203e, 

        BattleOver = 0x4b062919, 

        InventoryUpdated = 0x4b5e7202, 

        DoorStatusUpdate = 0x4c7d403b, 

        TeamInvite = 0x4d2a3a38, 

        ShopStatus = 0x4d333027, 

        InfoPacket = 0x4d38242e, 

        SpellList = 0x4d450114, 

        InventoryUpdate = 0x4e536976, 

        CorpseFullUpdate = 0x4f474e05, 

        Feedback = 0x50544d19, 

        CharSecSpecAttack = 0x51492120, 

        BankCorpse = 0x52213420, 

        GenericCmd = 0x52526858, 

        PathMoveCmd = 0x5266632a, 

        ArriveAtBs = 0x540e3b27, 

        CharDcMove = 0x54111123, 

        PlayfieldAllTowers = 0x55220726, 

        KnuBotFinishTrade = 0x55682b24, 

        KnuBotAnswerList = 0x55704d31, 

        StopLogout = 0x56353038, 

        CharInPlay = 0x570c2039, 

        ShopUpdate = 0x58362220, 

        MechInfo = 0x58574239, 

        RemovePet = 0x58742a0f, 

        PlayfieldAllCities = 0x59210126, 

        TrapItemFullUpdate = 0x59313928, 

        Inspect = 0x5a585f65, 

        PlayfieldTowerUpdateClient = 0x5b1e052c, 

        ServerPosDebugInfo = 0x5c240404, 

        QuestAlternative = 0x5c436609, 

        FullAuto = 0x5c4a493a, 

        ChatCmd = 0x5c525a7b, 

        MissedAttackInfo = 0x5c654b28, 

        KnuBotAppendText = 0x5d70532a, 

        CharacterAction = 0x5e477770, 

        HouseDisappeared = 0x5e5b6007, 

        Impulse = 0x5f4a4c6c, 

        PlayfieldAnarchyF = 0x5f4b1a39, 

        ChatText = 0x5f4b442a, 

        GameTime = 0x5f52412e, 

        SetWantedDirection = 0x60201d0e, 

        AoTransportSignal = 0x62741e15, 

        PetCommand = 0x63333303, 

        OrgServer = 0x64582a07, 

        SetStat = 0x6e5f566e, 

        SetName = 0x734e5a7b, 

        StopMovingCmd = 0x742e2314, 

        SpecialAttackInfo = 0x754f1115, 

        GiveQuestToMember = 0x77230927, 

        KnuBotStartTrade = 0x7864401d, 

        GfxTrigger = 0x7a222202, 

        ShopItemPrice = 0x7e00312f, 

        NewLevel = 0x7f405a16, 

        OrgClient = 0x7f4b3108, 

        VendingMachineFullUpdate = 0x7f544905, 
    }
}