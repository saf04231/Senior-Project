
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2019 18:31:35
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

IF OBJECT_ID(N'[dbo].[FK_usersplayer_sheets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[player_sheets] DROP CONSTRAINT [FK_usersplayer_sheets];
GO
IF OBJECT_ID(N'[dbo].[FK_gamesplayer_sheets_games]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gamesplayer_sheets] DROP CONSTRAINT [FK_gamesplayer_sheets_games];
GO
IF OBJECT_ID(N'[dbo].[FK_gamesplayer_sheets_player_sheets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gamesplayer_sheets] DROP CONSTRAINT [FK_gamesplayer_sheets_player_sheets];
GO
IF OBJECT_ID(N'[dbo].[FK_gamesmaps]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[maps] DROP CONSTRAINT [FK_gamesmaps];
GO
IF OBJECT_ID(N'[dbo].[FK_usersgames]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[games] DROP CONSTRAINT [FK_usersgames];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO
IF OBJECT_ID(N'[dbo].[games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[games];
GO
IF OBJECT_ID(N'[dbo].[player_sheets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[player_sheets];
GO
IF OBJECT_ID(N'[dbo].[maps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[maps];
GO
IF OBJECT_ID(N'[dbo].[database_firewall_rules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[database_firewall_rules];
GO
IF OBJECT_ID(N'[dbo].[gamesplayer_sheets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gamesplayer_sheets];
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
    [dm_Id] int  NOT NULL
);
GO

-- Creating table 'player_sheets'
CREATE TABLE [dbo].[player_sheets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL,
    [spells] nvarchar(max)  NULL,
    [notes] nvarchar(max)  NULL,
    [inventory] nvarchar(max)  NULL,
    [w1name] nvarchar(max)  NULL,
    [w1damage] int  NULL,
    [w1description] nvarchar(max)  NULL,
    [w1type] nvarchar(max)  NULL,
    [w2name] nvarchar(max)  NULL,
    [w2damage] int  NULL,
    [w2description] nvarchar(max)  NULL,
    [w2type] nvarchar(max)  NULL,
    [w3name] nvarchar(max)  NULL,
    [w3damage] int  NULL,
    [w3description] nvarchar(max)  NULL,
    [w3type] nvarchar(max)  NULL,
    [exp] int  NULL,
    [cp] int  NULL,
    [sp] int  NULL,
    [gp] int  NULL,
    [pp] int  NULL,
    [profBonus] int  NULL,
    [insp] int  NULL,
    [stre] int  NULL,
    [dext] int  NULL,
    [cont] int  NULL,
    [inte] int  NULL,
    [wisd] int  NULL,
    [chari] int  NULL,
    [passWis] int  NULL,
    [user_Id] int  NOT NULL
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

-- Creating table 'database_firewall_rules'
CREATE TABLE [dbo].[database_firewall_rules] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL,
    [start_ip_address] varchar(45)  NOT NULL,
    [end_ip_address] varchar(45)  NOT NULL,
    [create_date] datetime  NOT NULL,
    [modify_date] datetime  NOT NULL
);
GO

-- Creating table 'gamesplayer_sheets'
CREATE TABLE [dbo].[gamesplayer_sheets] (
    [games_Id] int  NOT NULL,
    [player_sheets_Id] int  NOT NULL
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

-- Creating primary key on [id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] in table 'database_firewall_rules'
ALTER TABLE [dbo].[database_firewall_rules]
ADD CONSTRAINT [PK_database_firewall_rules]
    PRIMARY KEY CLUSTERED ([id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] ASC);
GO

-- Creating primary key on [games_Id], [player_sheets_Id] in table 'gamesplayer_sheets'
ALTER TABLE [dbo].[gamesplayer_sheets]
ADD CONSTRAINT [PK_gamesplayer_sheets]
    PRIMARY KEY CLUSTERED ([games_Id], [player_sheets_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [games_Id] in table 'gamesplayer_sheets'
ALTER TABLE [dbo].[gamesplayer_sheets]
ADD CONSTRAINT [FK_gamesplayer_sheets_games]
    FOREIGN KEY ([games_Id])
    REFERENCES [dbo].[games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [player_sheets_Id] in table 'gamesplayer_sheets'
ALTER TABLE [dbo].[gamesplayer_sheets]
ADD CONSTRAINT [FK_gamesplayer_sheets_player_sheets]
    FOREIGN KEY ([player_sheets_Id])
    REFERENCES [dbo].[player_sheets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gamesplayer_sheets_player_sheets'
CREATE INDEX [IX_FK_gamesplayer_sheets_player_sheets]
ON [dbo].[gamesplayer_sheets]
    ([player_sheets_Id]);
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