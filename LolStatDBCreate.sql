﻿USE [LolStat]
GO
/****** Object:  Table [dbo].[Champions]    Script Date: 7/22/2015 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Champions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ChampionID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Games]    Script Date: 7/22/2015 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChampionID] [int] NOT NULL,
	[MapID] [int] NOT NULL,
	[GameTypeID] [int] NOT NULL,
	[Kills] [int] NOT NULL,
	[Deaths] [int] NOT NULL,
	[Assists] [int] NOT NULL,
	[Gold] [float] NOT NULL,
	[CreepScore] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
	[IsWin] [bit] NULL,
	[Level] [int] NOT NULL,
 CONSTRAINT [PK_GamesID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GameTypes]    Script Date: 7/22/2015 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_GameTypesID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maps]    Script Date: 7/22/2015 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MapsID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [Games_ChampionID_FK] FOREIGN KEY([ChampionID])
REFERENCES [dbo].[Champions] ([ID])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [Games_ChampionID_FK]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [Games_GameTypeID_FK] FOREIGN KEY([GameTypeID])
REFERENCES [dbo].[GameTypes] ([ID])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [Games_GameTypeID_FK]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [Games_MapID_FK] FOREIGN KEY([MapID])
REFERENCES [dbo].[Maps] ([ID])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [Games_MapID_FK]
GO