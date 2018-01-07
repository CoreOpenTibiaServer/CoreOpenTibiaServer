﻿namespace COTS.Infra.CrossCutting.Security.Enums
{
    public enum ClientPacketType : byte
    {
        LoginFirstMessageRequest = 0,
        LoginServerRequest = 0x01,
        GameServerRequest = 0x0A,
        Disconnect = 0x0F,

        Logout = 0x14,
        PingBack = 0x1D,
        Ping = 0x1E,

        AutoWalk = 0x64,
        MoveNorth = 0x65,
        MoveEast = 0x66,
        MoveSouth = 0x67,
        MoveWest = 0x68,
        StopAutoWalk = 0x69,
        MoveNorthEast = 0x6A,
        MoveSouthEast = 0x6B,
        MoveSouthWest = 0x6C,
        MoveNorthWest = 0x6D,
        TurnNorth = 0x6F,

        TurnEast = 0x70,
        TurnSouth = 0x71,
        TurnWest = 0x72,
        ItemMove = 0x78,
        ShopOpen = 0x79,
        ShopBuy = 0x7A,
        ShopSell = 0x7B,
        ShopClose = 0x7C,
        TradeRequest = 0x7D,
        TradeLook = 0x7E,
        TradeAccept = 0x7F,

        TradeClose = 0x80,
        ItemUse = 0x82,
        ItemUseOn = 0x83,
        ItemUseBattlelist = 0x84,
        ItemRotate = 0x85,
        ContainerClose = 0x87,
        ContainerOpenParent = 0x88,
        TextWindow = 0x89,
        HouseWindow = 0x8A,
        LookAt = 0x8C,
        LookInBattleWindow = 0x8D,
        JoinAggression = 0x8E,

        PlayerSpeech = 0x96,
        ChannelList = 0x97,
        ChannelOpen = 0x98,
        ChannelClose = 0x99,
        PrivateChannelOpen = 0x9A,
        NpcChannelClose = 0x9E,

        FightModes = 0xA0,
        Attack = 0xA1,
        Follow = 0xA2,
        PartyInvite = 0xA3,
        PartyJoin = 0xA4,
        PartyInviteRevoke = 0xA5,
        PartyPassLeadership = 0xA6,
        PartyLeave = 0xA7,
        PartySharedExperienceEnable = 0xA8,
        PrivateChannelCreate = 0xAA,
        PrivateChannelInvite = 0xAB,
        PrivateChannelExclude = 0xAC,

        CancelAttackAndFollow = 0xBE,

        UpdateTile = 0xC9,
        UpdateContainer = 0xCA,
        BrowseField = 0xCB,
        SeekInContainer = 0xCC,

        RequestOutfit = 0xD2,
        ChangeOutfit = 0xD3,
        ToggleMount = 0xD4,
        VipAdd = 0xDC,
        VipRemove = 0xDD,
        VipEdit = 0xDE,

        BugReport = 0xE6,
        ThankYou = 0xE7,
        DebugAssert = 0xE8,

        QuestShowLog = 0xF0,
        QuestLine = 0xF1,
        RuleViolationReport = 0xF2,
        GetObjectInfo = 0xF3,
        MarketLeave = 0xF4,
        MarketBrowse = 0xF5,
        MarketCreateOffer = 0xF6,
        MarketCancelOffer = 0xF7,
        MarketAcceptOffer = 0xF8,
        ModalWindowAnswer = 0xF9,
    }
}