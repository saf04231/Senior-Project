
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2019 23:14:56
-- Generated from EDMX file: C:\Users\sferl\Documents\GitHub\Senior-Project\DADS\DADS\ZeroHP_DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ZeroHP0_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_gamesmaps]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[maps] DROP CONSTRAINT [FK_gamesmaps];
GO
IF OBJECT_ID(N'[dbo].[FK_gamesplayer_sheets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[player_sheets] DROP CONSTRAINT [FK_gamesplayer_sheets];
GO
IF OBJECT_ID(N'[dbo].[FK_usersgames]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[games] DROP CONSTRAINT [FK_usersgames];
GO
IF OBJECT_ID(N'[dbo].[FK_usersgames1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[games] DROP CONSTRAINT [FK_usersgames1];
GO
IF OBJECT_ID(N'[dbo].[FK_usersplayer_sheets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[player_sheets] DROP CONSTRAINT [FK_usersplayer_sheets];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[games];
GO
IF OBJECT_ID(N'[dbo].[maps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[maps];
GO
IF OBJECT_ID(N'[dbo].[player_sheets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[player_sheets];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'games'
CREATE TABLE [dbo].[games] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL,
    [players_Id] int  NULL,
    [dm_Id] int  NOT NULL
);
GO

-- Creating table 'player_sheets'
CREATE TABLE [dbo].[player_sheets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL,
    [stats] nvarchar(max)  NOT NULL,
    [spells] nvarchar(max)  NULL,
    [notes] nvarchar(max)  NULL,
    [weapon1] varchar(3)  NULL,
    [weapon2] varchar(3)  NULL,
    [weapon3] varchar(3)  NULL,
    [statslist] varchar(3)  NOT NULL,
    [user_Id] int  NOT NULL,
    [games_Id] int  NULL
);
GO

-- Creating table 'maps'
CREATE TABLE [dbo].[maps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [image] nvarchar(max)  NOT NULL,
    [drawings] nvarchar(max)  NULL,
    [gamesId] int  NOT NULL,
    [name] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'games'
ALTER TABLE [dbo].[games]
ADD CONSTRAINT [PK_games]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'player_sheets'
ALTER TABLE [dbo].[player_sheets]
ADD CONSTRAINT [PK_player_sheets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'maps'
ALTER TABLE [dbo].[maps]
ADD CONSTRAINT [PK_maps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [players_Id] in table 'games'
ALTER TABLE [dbo].[games]
ADD CONSTRAINT [FK_usersgames1]
    FOREIGN KEY ([players_Id])
    REFERENCES [dbo].[users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usersgames1'
CREATE INDEX [IX_FK_usersgames1]
ON [dbo].[games]
    ([players_Id]);
GO

-- Creating foreign key on [user_Id] in table 'player_sheets'
ALTER TABLE [dbo].[player_sheets]
ADD CONSTRAINT [FK_usersplayer_sheets]
    FOREIGN KEY ([user_Id])
    REFERENCES [dbo].[users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usersplayer_sheets'
CREATE INDEX [IX_FK_usersplayer_sheets]
ON [dbo].[player_sheets]
    ([user_Id]);
GO

-- Creating foreign key on [games_Id] in table 'player_sheets'
ALTER TABLE [dbo].[player_sheets]
ADD CONSTRAINT [FK_gamesplayer_sheets]
    FOREIGN KEY ([games_Id])
    REFERENCES [dbo].[games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gamesplayer_sheets'
CREATE INDEX [IX_FK_gamesplayer_sheets]
ON [dbo].[player_sheets]
    ([games_Id]);
GO

-- Creating foreign key on [gamesId] in table 'maps'
ALTER TABLE [dbo].[maps]
ADD CONSTRAINT [FK_gamesmaps]
    FOREIGN KEY ([gamesId])
    REFERENCES [dbo].[games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gamesmaps'
CREATE INDEX [IX_FK_gamesmaps]
ON [dbo].[maps]
    ([gamesId]);
GO

-- Creating foreign key on [dm_Id] in table 'games'
ALTER TABLE [dbo].[games]
ADD CONSTRAINT [FK_usersgames]
    FOREIGN KEY ([dm_Id])
    REFERENCES [dbo].[users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usersgames'
CREATE INDEX [IX_FK_usersgames]
ON [dbo].[games]
    ([dm_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------