
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2019 16:13:13
-- Generated from EDMX file: C:\Users\usrsis0156\Pictures\test\test\testApplication.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [testApplication];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_album_artista]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[album] DROP CONSTRAINT [FK_album_artista];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[album]', 'U') IS NOT NULL
    DROP TABLE [dbo].[album];
GO
IF OBJECT_ID(N'[dbo].[artista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[artista];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'album'
CREATE TABLE [dbo].[album] (
    [idAlbum] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(100)  NULL,
    [genero] nchar(100)  NULL,
    [fecha] datetime  NULL,
    [idArtista] int  NULL
);
GO

-- Creating table 'artista'
CREATE TABLE [dbo].[artista] (
    [idArtista] int IDENTITY(1,1) NOT NULL,
    [nameArtista] nchar(100)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [idUsername] int  NOT NULL,
    [username] varchar(25)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idAlbum] in table 'album'
ALTER TABLE [dbo].[album]
ADD CONSTRAINT [PK_album]
    PRIMARY KEY CLUSTERED ([idAlbum] ASC);
GO

-- Creating primary key on [idArtista] in table 'artista'
ALTER TABLE [dbo].[artista]
ADD CONSTRAINT [PK_artista]
    PRIMARY KEY CLUSTERED ([idArtista] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [idUsername] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [PK_usuarios]
    PRIMARY KEY CLUSTERED ([idUsername] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idArtista] in table 'album'
ALTER TABLE [dbo].[album]
ADD CONSTRAINT [FK_album_artista]
    FOREIGN KEY ([idArtista])
    REFERENCES [dbo].[artista]
        ([idArtista])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_album_artista'
CREATE INDEX [IX_FK_album_artista]
ON [dbo].[album]
    ([idArtista]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------