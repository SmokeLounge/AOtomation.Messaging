// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterStat.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CharacterStat type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    public enum CharacterStat
    {
        Flags = 0x00000000, 

        MaxHealth = 0x00000001, 

        Mass = 0x00000002, 

        AttackSpeed = 0x00000003, 

        Breed = 0x00000004, 

        Clan = 0x00000005, 

        Team = 0x00000006, 

        State = 0x00000007, 

        TimeExist = 0x00000008, 

        MapFlags = 0x00000009, 

        ProfessionLevel = 0x0000000A, 

        PreviousHealth = 0x0000000B, 

        Mesh = 0x0000000C, 

        Anim = 0x0000000D, 

        Name = 0x0000000E, 

        Info = 0x0000000F, 

        Strength = 0x00000010, 

        Agility = 0x00000011, 

        Stamina = 0x00000012, 

        Intelligence = 0x00000013, 

        Sense = 0x00000014, 

        Psychic = 0x00000015, 

        AMS = 0x00000016, 

        StaticInstance = 0x00000017, 

        MaxMass = 0x00000018, 

        StaticType = 0x00000019, 

        Energy = 0x0000001A, 

        Health = 0x0000001B, 

        Height = 0x0000001C, 

        DMS = 0x0000001D, 

        Can = 0x0000001E, 

        Face = 0x0000001F, 

        HairMesh = 0x00000020, 

        Side = 0x00000021, 

        DeadTimer = 0x00000022, 

        AccessCount = 0x00000023, 

        AttackCount = 0x00000024, 

        TitleLevel = 0x00000025, 

        BackMesh = 0x00000026, 

        ShoulderMesh = 0x00000027, 

        AlienXP = 0x00000028, 

        FabricType = 0x00000029, 

        CATMesh = 0x0000002A, 

        ParentType = 0x0000002B, 

        ParentInstance = 0x0000002C, 

        BeltSlots = 0x0000002D, 

        BandolierSlots = 0x0000002E, 

        Fatness = 0x0000002F, 

        ClanLevel = 0x00000030, 

        InsuranceTime = 0x00000031, 

        AggDef = 0x00000033, 

        XP = 0x00000034, 

        IP = 0x00000035, 

        LevelNCUCost = 0x00000036, 

        InventoryId = 0x00000037, 

        TimeSinceCreation = 0x00000038, 

        LastXP = 0x00000039, 

        Age = 0x0000003A, 

        Sex = 0x0000003B, 

        Profession = 0x0000003C, 

        Cash = 0x0000003D, 

        AlignmentClanTokens = 0x0000003E, 

        Attitude = 0x0000003F, 

        HeadMesh = 0x00000040, 

        HairTexture = 0x00000041, 

        HairColourRGB = 0x00000043, 

        NumConstructedQuest = 0x00000044, 

        MaxConstructedQuest = 0x00000045, 

        SpeedPenalty = 0x00000046, 

        ItemType = 0x00000048, 

        RepairDifficulty = 0x00000049, 

        Value = 0x0000004A, 

        StrainOmniTokens = 0x0000004B, 

        EquipmentPage = 0x0000004C, 

        RepairSkill = 0x0000004D, 

        CurrentMass = 0x0000004E, 

        Icon = 0x0000004F, 

        PrimaryItemType = 0x00000050, 

        PrimaryItemInstance = 0x00000051, 

        SecondaryItemType = 0x00000052, 

        SecondaryItemInstance = 0x00000053, 

        UserType = 0x00000054, 

        UserInstance = 0x00000055, 

        AreaType = 0x00000056, 

        AreaInstance = 0x00000057, 

        DefaultPos = 0x00000058, 

        Race = 0x00000059, 

        ProjectileAC = 0x0000005A, 

        MeleeAC = 0x0000005B, 

        EnergyAC = 0x0000005C, 

        ChemicalAC = 0x0000005D, 

        RadiationAC = 0x0000005E, 

        ColdAC = 0x0000005F, 

        PoisonAC = 0x00000060, 

        FireAC = 0x00000061, 

        StateAction = 0x00000062, 

        ItemAnim = 0x00000063, 

        MartialArts = 0x00000064, 

        MultiMelee = 0x00000065, 

        _1hBlunt = 0x00000066, 

        _1hEdged = 0x00000067, 

        MeleeEnergy = 0x00000068, 

        Skill2hEdged = 0x00000069, 

        Piercing = 0x0000006A, 

        _2hBlunt = 0x0000006B, 

        SharpObject = 0x0000006C, 

        Grenade = 0x0000006D, 

        HeavyWeapons = 0x0000006E, 

        Bow = 0x0000006F, 

        Pistol = 0x00000070, 

        Rifle = 0x00000071, 

        MGSMG = 0x00000072, 

        Shotgun = 0x00000073, 

        AssaultRifle = 0x00000074, 

        VehicleWater = 0x00000075, 

        MeleeInit = 0x00000076, 

        RangedInit = 0x00000077, 

        PhysicalInit = 0x00000078, 

        BowSpecialAttack = 0x00000079, 

        SensoryImprovement = 0x0000007A, 

        FirstAid = 0x0000007B, 

        Treatment = 0x0000007C, 

        MechanicalEngineering = 0x0000007D, 

        ElectricalEngineering = 0x0000007E, 

        MaterialMetamorphosis = 0x0000007F, 

        BiologicalMetamorphosis = 0x00000080, 

        PsychologicalModification = 0x00000081, 

        MaterialCreation = 0x00000082, 

        SpaceTime = 0x00000083, 

        NanoPool = 0x00000084, 

        RangedEnergy = 0x00000085, 

        MultiRanged = 0x00000086, 

        TrapDisarm = 0x00000087, 

        Perception = 0x00000088, 

        Adventuring = 0x00000089, 

        Swimming = 0x0000008A, 

        VehicleAir = 0x0000008B, 

        MapNavigation = 0x0000008C, 

        Tutoring = 0x0000008D, 

        Brawl = 0x0000008E, 

        Riposte = 0x0000008F, 

        Dimach = 0x00000090, 

        Parry = 0x00000091, 

        SneakAttack = 0x00000092, 

        FastAttack = 0x00000093, 

        Burst = 0x00000094, 

        NanoCInit = 0x00000095, 

        FlingShot = 0x00000096, 

        AimedShot = 0x00000097, 

        BodyDevelopment = 0x00000098, 

        DuckExp = 0x00000099, 

        DodgeRanged = 0x0000009A, 

        EvadeClsC = 0x0000009B, 

        RunSpeed = 0x0000009C, 

        QuantumFT = 0x0000009D, 

        WeaponSmithing = 0x0000009E, 

        Pharmaceuticals = 0x0000009F, 

        NanoProgramming = 0x000000A0, 

        ComputerLiteracy = 0x000000A1, 

        Psychology = 0x000000A2, 

        Chemistry = 0x000000A3, 

        Concealment = 0x000000A4, 

        BreakingEntry = 0x000000A5, 

        VehicleGround = 0x000000A6, 

        FullAuto = 0x000000A7, 

        NanoResist = 0x000000A8, 

        AlienLevel = 0x000000A9, 

        HealthChangeBest = 0x000000AA, 

        HealthChangeWorst = 0x000000AB, 

        HealthChange = 0x000000AC, 

        MoreFlags = 0x000000B1, 

        AlienNextXP = 0x000000B2, 

        NPCFlags = 0x000000B3, 

        CurrentNCU = 0x000000B4, 

        MaxNCU = 0x000000B5, 

        Specialization = 0x000000B6, 

        EffectIcon = 0x000000B7, 

        BuildingType = 0x000000B8, 

        BuildingInstance = 0x000000B9, 

        CardOwnerType = 0x000000BA, 

        CardOwnerInstance = 0x000000BB, 

        BuildingComplexInst = 0x000000BC, 

        ExitInstance = 0x000000BD, 

        NextDoorInBuilding = 0x000000BE, 

        LastConcretePlayfieldInstance = 0x000000BF, 

        ExtenalPlayfieldInstance = 0x000000C0, 

        ExtenalDoorInstance = 0x000000C1, 

        InPlay = 0x000000C2, 

        AccessKey = 0x000000C3, 

        ConflictReputation = 0x000000C4, 

        OrientationMode = 0x000000C5, 

        SessionTime = 0x000000C6, 

        RP = 0x000000C7, 

        Conformity = 0x000000C8, 

        Aggressiveness = 0x000000C9, 

        Stability = 0x000000CA, 

        Extroverty = 0x000000CB, 

        Taunt = 0x000000CC, 

        ReflectProjectileAC = 0x000000CD, 

        ReflectMeleeAC = 0x000000CE, 

        ReflectEnergyAC = 0x000000CF, 

        ReflectChemicalAC = 0x000000D0, 

        WeaponMesh = 0x000000D1, 

        RechargeDelay = 0x000000D2, 

        EquipDelay = 0x000000D3, 

        MaxEnergy = 0x000000D4, 

        TeamSide = 0x000000D5, 

        CurrentNano = 0x000000D6, 

        GmLevel = 0x000000D7, 

        ReflectRadiationAC = 0x000000D8, 

        ReflectColdAC = 0x000000D9, 

        ReflectNanoAC = 0x000000DA, 

        ReflectFireAC = 0x000000DB, 

        CurrBodyLocation = 0x000000DC, 

        MaxNanoEnergy = 0x000000DD, 

        AccumulatedDamage = 0x000000DE, 

        CanChangeClothes = 0x000000DF, 

        Features = 0x000000E0, 

        ReflectPoisonAC = 0x000000E1, 

        ShieldProjectileAC = 0x000000E2, 

        ShieldMeleeAC = 0x000000E3, 

        ShieldEnergyAC = 0x000000E4, 

        ShieldChemicalAC = 0x000000E5, 

        ShieldRadiationAC = 0x000000E6, 

        ShieldColdAC = 0x000000E7, 

        ShieldNanoAC = 0x000000E8, 

        ShieldFireAC = 0x000000E9, 

        ShieldPoisonAC = 0x000000EA, 

        BerserkMode = 0x000000EB, 

        InsurancePercentage = 0x000000EC, 

        ChangeSideCount = 0x000000ED, 

        AbsorbProjectileAC = 0x000000EE, 

        AbsorbMeleeAC = 0x000000EF, 

        AbsorbEnergyAC = 0x000000F0, 

        AbsorbChemicalAC = 0x000000F1, 

        AbsorbRadiationAC = 0x000000F2, 

        AbsorbColdAC = 0x000000F3, 

        AbsorbFireAC = 0x000000F4, 

        AbsorbPoisonAC = 0x000000F5, 

        AbsorbNanoAC = 0x000000F6, 

        TemporarySkillReduction = 0x000000F7, 

        BirthDate = 0x000000F8, 

        LastSaved = 0x000000F9, 

        SoundVolume = 0x000000FA, 

        Pets = 0x000000FB, 

        MetersWalked = 0x000000FC, 

        QuestLevelsSolved = 0x000000FD, 

        MonsterLevelsKilled = 0x000000FE, 

        PvPLevelsKilled = 0x000000FF, 

        MissionBits1 = 0x00000100, 

        MissionBits2 = 0x00000101, 

        ClanHierarchy = 0x00000104, 

        QuestStat = 0x00000105, 

        ClientActivated = 0x00000106, 

        PersonalResearchLevel = 0x00000107, 

        GlobalResearchLevel = 0x00000108, 

        PersonalResearchGoal = 0x00000109, 

        GlobalResearchGoal = 0x0000010A, 

        TurnSpeed = 0x0000010B, 

        LiquidType = 0x0000010C, 

        GatherSound = 0x0000010D, 

        CastSound = 0x0000010E, 

        TravelSound = 0x0000010F, 

        HitSound = 0x00000110, 

        SecondaryItemTemplate = 0x00000111, 

        EquippedWeapons = 0x00000112, 

        XPKillRange = 0x00000113, 

        AddAllOff = 0x00000114, 

        AddAllDef = 0x00000115, 

        ProjectileDamageModifier = 0x00000116, 

        MeleeDamageModifier = 0x00000117, 

        EnergyDamageModifier = 0x00000118, 

        ChemicalDamageModifier = 0x00000119, 

        RadiationDamageModifier = 0x0000011A, 

        ItemHateValue = 0x0000011B, 

        CriticalBonus = 0x0000011C, 

        MaxDamage = 0x0000011D, 

        MinDamage = 0x0000011E, 

        AttackRange = 0x0000011F, 

        HateValueModifier = 0x00000120, 

        TrapDifficulty = 0x00000121, 

        StatOne = 0x00000122, 

        NumAttackEffects = 0x00000123, 

        DefaultAttackType = 0x00000124, 

        ItemSkill = 0x00000125, 

        AttackDelay = 0x00000126, 

        ItemOpposedSkill = 0x00000127, 

        ItemSIS = 0x00000128, 

        InteractionRadius = 0x00000129, 

        Slot = 0x0000012A, 

        LockDifficulty = 0x0000012B, 

        Members = 0x0000012C, 

        MinMembers = 0x0000012D, 

        ClanPrice = 0x0000012E, 

        ClanUpkeep = 0x0000012F, 

        ClanType = 0x00000130, 

        ClanInstance = 0x00000131, 

        VoteCount = 0x00000132, 

        MemberType = 0x00000133, 

        MemberInstance = 0x00000134, 

        GlobalClanType = 0x00000135, 

        GlobalClanInstance = 0x00000136, 

        ColdDamageModifier = 0x00000137, 

        ClanUpkeepInterval = 0x00000138, 

        TimeSinceUpkeep = 0x00000139, 

        ClanFinalized = 0x0000013A, 

        NanoDamageModifier = 0x0000013B, 

        FireDamageModifier = 0x0000013C, 

        PoisonDamageModifier = 0x0000013D, 

        NPCostModifier = 0x0000013E, 

        XPModifier = 0x0000013F, 

        BreedLimit = 0x00000140, 

        GenderLimit = 0x00000141, 

        LevelLimit = 0x00000142, 

        PlayerKilling = 0x00000143, 

        TeamAllowed = 0x00000144, 

        WeaponDisallowedType = 0x00000145, 

        WeaponDisallowedInstance = 0x00000146, 

        Taboo = 0x00000147, 

        Compulsion = 0x00000148, 

        SkillDisabled = 0x00000149, 

        ClanItemType = 0x0000014A, 

        ClanItemInstance = 0x0000014B, 

        DebuffFormula = 0x0000014C, 

        PvP_Rating = 0x0000014D, 

        SavedXP = 0x0000014E, 

        DamageType1 = 0x00000153, 

        BrainType = 0x00000154, 

        XPBonus = 0x00000155, 

        HealInterval = 0x00000156, 

        HealDelta = 0x00000157, 

        MonsterTexture = 0x00000158, 

        HasAlwaysLootable = 0x00000159, 

        NextXP = 0x0000015E, 

        SISCap = 0x00000160, 

        AnimSet = 0x00000161, 

        AttackType = 0x00000162, 

        NanoFocusLevel = 0x00000163, 

        MonsterData = 0x00000167, 

        Scale = 0x00000168, 

        HitEffectType = 0x00000169, 

        ResurrectDest = 0x0000016A, 

        NanoInterval = 0x0000016B, 

        NanoDelta = 0x0000016C, 

        ReclaimItem = 0x0000016D, 

        GatherEffectType = 0x0000016E, 

        VisualBreed = 0x0000016F, 

        VisualProfession = 0x00000170, 

        VisualSex = 0x00000171, 

        RitualTargetInst = 0x00000172, 

        SkillTimeOnSelectedTarget = 0x00000173, 

        LastSaveXP = 0x00000174, 

        ExtendedTime = 0x00000175, 

        BurstRecharge = 0x00000176, 

        FullAutoRecharge = 0x00000177, 

        GatherAbstractAnim = 0x00000178, 

        CastTargetAbstractAnim = 0x00000179, 

        CastSelfAbstractAnim = 0x0000017A, 

        CriticalIncrease = 0x0000017B, 

        WeaponRange = 0x0000017C, 

        NanoRange = 0x0000017D, 

        SkillLockModifier = 0x0000017E, 

        InterruptModifier = 0x0000017F, 

        ACGEntranceStyles = 0x00000180, 

        ChanceOfBreakOnSpellAttack = 0x00000181, 

        ChanceOfBreakOnDebuff = 0x00000182, 

        DieAnim = 0x00000183, 

        TowerType = 0x00000184, 

        Expansion = 0x00000185, 

        LowresMesh = 0x00000186, 

        CritialResistance = 0x00000187, 

        SelectedTargetType = 0x0000018D, 

        Corpse_Hash = 0x0000018E, 

        AmmoName = 0x0000018F, 

        Rotation = 0x00000190, 

        CATAnim = 0x00000191, 

        CATAnimFlags = 0x00000192, 

        DisplayCATAnim = 0x00000193, 

        DisplayCATMesh = 0x00000194, 

        School = 0x00000195, 

        NanoPoints = 0x00000197, 

        TrainSkill = 0x00000198, 

        TrainSkillCost = 0x00000199, 

        IsFightingMe = 0x0000019A, 

        MultipleCount = 0x0000019C, 

        EffectType = 0x0000019D, 

        ImpactEffectType = 0x0000019E, 

        CorpseType = 0x0000019F, 

        CorpseInstance = 0x000001A0, 

        CorpseAnimKey = 0x000001A1, 

        UnarmedTemplateInstance = 0x000001A2, 

        TracerEffectType = 0x000001A3, 

        AmmoType = 0x000001A4, 

        CharRadius = 0x000001A5, 

        ChanceOfUse = 0x000001A6, 

        CurrentState = 0x000001A7, 

        ArmourType = 0x000001A8, 

        RestModifier = 0x000001A9, 

        BuyModifier = 0x000001AA, 

        SellModifier = 0x000001AB, 

        CastEffectType = 0x000001AC, 

        NPCBrainState = 0x000001AD, 

        WaitState = 0x000001AE, 

        SelectedTarget = 0x000001AF, 

        ErrorCode = 0x000001B0, 

        OwnerInstance = 0x000001B1, 

        CharState = 0x000001B2, 

        ReadOnly = 0x000001B3, 

        DamageType2 = 0x000001B4, 

        CollideCheckInterval = 0x000001B5, 

        PlayfieldType = 0x000001B6, 

        NPCCommand = 0x000001B7, 

        InitiativeType = 0x000001B8, 

        CharTmp1 = 0x000001B9, 

        CharTmp2 = 0x000001BA, 

        CharTmp3 = 0x000001BB, 

        CharTmp4 = 0x000001BC, 

        NPCCommandArg = 0x000001BD, 

        NameTemplate = 0x000001BE, 

        DesiredTargetDistance = 0x000001BF, 

        VicinityRange = 0x000001C0, 

        NPCIsSurrendering = 0x000001C1, 

        StateMachine = 0x000001C2, 

        NPCSurrenderInstance = 0x000001C3, 

        NPCHasPatrolList = 0x000001C4, 

        NPCVicinityChars = 0x000001C5, 

        ProximityRangeOutdoors = 0x000001C6, 

        NPCFamily = 0x000001C7, 

        CommandRange = 0x000001C8, 

        NPCHatelistSize = 0x000001C9, 

        NPCNumPets = 0x000001CA, 

        EffectRed = 0x000001CC, 

        EffectGreen = 0x000001CD, 

        EffectBlue = 0x000001CE, 

        DurationModifier = 0x000001D0, 

        NPCCryForHelpRange = 0x000001D1, 

        PetReq1 = 0x000001D3, 

        PetReq2 = 0x000001D4, 

        PetReq3 = 0x000001D5, 

        MapOptions = 0x000001D6, 

        MapsA = 0x000001D7, 

        MapsB = 0x000001D8, 

        FixtureFlags = 0x000001D9, 

        FallDamage = 0x000001DA, 

        MaxReflectedProjectileDmg = 0x000001DB, 

        MaxReflectedMeleeDmg = 0x000001DC, 

        MaxReflectedEnergyDmg = 0x000001DD, 

        MaxReflectedChemicalDmg = 0x000001DE, 

        MaxReflectedRadiationDmg = 0x000001DF, 

        MaxReflectedColdDmg = 0x000001E0, 

        MaxReflectedNanoDmg = 0x000001E1, 

        MaxReflectedFireDmg = 0x000001E2, 

        MaxReflectedPoisonDmg = 0x000001E3, 

        ProximityRangeIndoors = 0x000001E4, 

        PetReqVal1 = 0x000001E5, 

        PetReqVal2 = 0x000001E6, 

        PetReqVal3 = 0x000001E7, 

        TargetFacing = 0x000001E8, 

        Backstab = 0x000001E9, 

        OriginatorType = 0x000001EA, 

        QuestInstance = 0x000001EB, 

        AnimPos = 0x000001F4, 

        AnimPlay = 0x000001F5, 

        AnimSpeed = 0x000001F6, 

        Tower_NPCHash = 0x000001FF, 

        PetType = 0x00000200, 

        OnTowerCreation = 0x00000201, 

        OwnedTowers = 0x00000202, 

        TowerInstance = 0x00000203, 

        AttackShield = 0x00000204, 

        SpecialAttackShield = 0x00000205, 

        NPCVicinityPlayers = 0x00000206, 

        Rnd = 0x00000208, 

        SocialStatus = 0x00000209, 

        LastRnd = 0x0000020A, 

        AttackDelayCap = 0x0000020B, 

        RechargeDelayCap = 0x0000020C, 

        PercentRemainingHealth = 0x0000020D, 

        PercentRemainingNano = 0x0000020E, 

        TargetDistance = 0x0000020F, 

        TeamCloseness = 0x00000210, 

        ExpansionPlayfield = 0x00000213, 

        ShadowBreed = 0x00000214, 

        DudChance = 0x00000216, 

        HealMultiplier = 0x00000217, 

        NanoDamageMultiplier = 0x00000218, 

        NanoVulnerability = 0x00000219, 

        AMSCap = 0x0000021A, 

        ProcInitiative1 = 0x0000021B, 

        ProcInitiative2 = 0x0000021C, 

        ProcInitiative3 = 0x0000021D, 

        ProcInitiative4 = 0x0000021E, 

        FactionModifier = 0x0000021F, 

        StackingLine2 = 0x00000222, 

        StackingLine3 = 0x00000223, 

        StackingLine4 = 0x00000224, 

        StackingLine5 = 0x00000225, 

        StackingLine6 = 0x00000226, 

        StackingOrder = 0x00000227, 

        ProcNano1 = 0x00000228, 

        ProcNano2 = 0x00000229, 

        ProcNano3 = 0x0000022A, 

        ProcNano4 = 0x0000022B, 

        ProcChance1 = 0x0000022C, 

        ProcChance2 = 0x0000022D, 

        ProcChance3 = 0x0000022E, 

        ProcChance4 = 0x0000022F, 

        OTArmedForces = 0x00000230, 

        ClanSentinels = 0x00000231, 

        OTMed = 0x00000232, 

        ClanGaia = 0x00000233, 

        OTTrans = 0x00000234, 

        ClanVanguards = 0x00000235, 

        GOS = 0x00000236, 

        OTFollowers = 0x00000237, 

        OTOperator = 0x00000238, 

        OTUnredeemed = 0x00000239, 

        ClanDevoted = 0x0000023A, 

        ClanConserver = 0x0000023B, 

        ClanRedeemed = 0x0000023C, 

        SK = 0x0000023D, 

        LastSK = 0x0000023E, 

        NextSK = 0x0000023F, 

        PlayerOptions = 0x00000240, 

        LastPerkResetTime = 0x00000241, 

        CurrentTime = 0x00000242, 

        ShadowBreedTemplate = 0x00000243, 

        NPCVicinityFamily = 0x00000244, 

        NPCScriptAMSScale = 0x00000245, 

        ApartmentsAllowed = 0x00000246, 

        ApartmentsOwned = 0x00000247, 

        ApartmentAccessCard = 0x00000248, 

        MapsC = 0x00000249, 

        MapsD = 0x0000024A, 

        NumberOfTeamMembers = 0x0000024B, 

        ActionCategory = 0x0000024C, 

        PlayfieldProxy = 0x0000024D, 

        UnsavedXP = 0x00000250, 

        RegainXPPercentage = 0x00000251, 

        ExtendedFlags = 0x00000256, 

        NewbieHP = 0x00000258, 

        HPLevelUp = 0x00000259, 

        HPPerSkill = 0x0000025A, 

        NewbieNP = 0x0000025B, 

        NPLevelUp = 0x0000025C, 

        NPPerSkill = 0x0000025D, 

        MaxShopItems = 0x0000025E, 

        PlayerID = 0x0000025F, 

        ShopRent = 0x00000260, 

        ShopFlags = 0x00000262, 

        ShopLastUsed = 0x00000263, 

        ShopType = 0x00000264, 

        InvadersKilled = 0x00000267, 

        KilledByInvaders = 0x00000268, 

        HouseTemplate = 0x0000026C, 

        PercentFireDamage = 0x0000026D, 

        PercentColdDamage = 0x0000026E, 

        PercentMeleeDamage = 0x0000026F, 

        PercentProjectileDamage = 0x00000270, 

        PercentPoisonDamage = 0x00000271, 

        PercentRadiationDamage = 0x00000272, 

        PercentEnergyDamage = 0x00000273, 

        PercentChemicalDamage = 0x00000274, 

        TotalDamage = 0x00000275, 

        TrackProjectileDamage = 0x00000276, 

        TrackMeleeDamage = 0x00000277, 

        TrackEnergyDamage = 0x00000278, 

        TrackChemicalDamage = 0x00000279, 

        TrackRadiationDamage = 0x0000027A, 

        TrackColdDamage = 0x0000027B, 

        TrackPoisonDamage = 0x0000027C, 

        TrackFireDamage = 0x0000027D, 

        NPCSpellArg = 0x0000027E, 

        NPCSpellRet = 0x0000027F, 

        CityInstance = 0x00000280, 

        DistanceToSpawnpoint = 0x00000281, 

        AdvantageHash1 = 0x0000028B, 

        AdvantageHash2 = 0x0000028C, 

        AdvantageHash3 = 0x0000028D, 

        AdvantageHash4 = 0x0000028E, 

        AdvantageHash5 = 0x0000028F, 

        ShopIndex = 0x00000290, 

        ShopID = 0x00000291, 

        IsVehicle = 0x00000292, 

        DamageToNano = 0x00000293, 

        AccountFlags = 0x00000294, 

        DamageToNanoMultiplier = 0x00000295, 

        MechData = 0x00000296, 

        PointValue = 0x00000297, 

        VehicleAC = 0x00000298, 

        VehicleDamage = 0x00000299, 

        VehicleHealth = 0x0000029A, 

        VehicleSpeed = 0x0000029B, 

        BattlestationSide = 0x0000029C, 

        VP = 0x0000029D, 

        BattlestationRep = 0x0000029E, 

        PetState = 0x0000029F, 

        PaidPoints = 0x000002A0, 

        VisualFlags = 0x000002A1, 

        PVPDuelKills = 0x000002A2, 

        PVPDuelDeaths = 0x000002A3, 

        PVPProfessionDuelKills = 0x000002A4, 

        PVPProfessionDuelDeaths = 0x000002A5, 

        PVPRankedSoloKills = 0x000002A6, 

        PVPRankedSoloDeaths = 0x000002A7, 

        PVPRankedTeamKills = 0x000002A8, 

        PVPRankedTeamDeaths = 0x000002A9, 

        PVPSoloScore = 0x000002AA, 

        PVPTeamScore = 0x000002AB, 

        PVPDuelScore = 0x000002AC, 

        ACGItemSeed = 0x000002BC, 

        ACGItemLevel = 0x000002BD, 

        ACGItemTemplateID = 0x000002BE, 

        ACGItemTemplateID2 = 0x000002BF, 

        ACGItemCategoryID = 0x000002C0, 

        HasKnubotData = 0x00000300, 

        QuestBoothDifficulty = 0x00000320, 

        QuestASMinimumRange = 0x00000321, 

        QuestASMaximumRange = 0x00000322, 

        VisualLODLevel = 0x00000378, 

        TargetDistanceChange = 0x00000379, 

        TideRequiredDynelID = 0x00000384, 

        Type = 0x000003E9, 

        Instance = 0x000003EA, 
    }
}