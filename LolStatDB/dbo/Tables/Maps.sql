﻿CREATE TABLE [dbo].[Maps] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MapsID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

