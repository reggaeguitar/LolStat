CREATE TABLE [dbo].[Games] (
    [ID]         INT        IDENTITY (1, 1) NOT NULL,
    [ChampionID] INT        NOT NULL,
    [MapID]      INT        NOT NULL,
    [GameTypeID] INT        NOT NULL,
    [Kills]      INT        NOT NULL,
    [Deaths]     INT        NOT NULL,
    [Assists]    INT        NOT NULL,
    [Gold]       FLOAT (53) NOT NULL,
    [CreepScore] INT        NOT NULL,
    [Date]       DATE       NOT NULL,
    [Time]       TIME (7)   NOT NULL,
    [IsWin]      BIT        NULL,
    [Level]      INT        NOT NULL,
    CONSTRAINT [PK_GamesID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Games_ChampionID_FK] FOREIGN KEY ([ChampionID]) REFERENCES [dbo].[Champions] ([ID]),
    CONSTRAINT [Games_GameTypeID_FK] FOREIGN KEY ([GameTypeID]) REFERENCES [dbo].[GameTypes] ([ID]),
    CONSTRAINT [Games_MapID_FK] FOREIGN KEY ([MapID]) REFERENCES [dbo].[Maps] ([ID])
);

