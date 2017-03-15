
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2017 23:43:34
-- Generated from EDMX file: C:\Users\mauri\Source\Repos\Project-IHFF\Project-IHFF\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [iHFF1617S_B2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MapLocationsSet'
CREATE TABLE [dbo].[MapLocationsSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [placeName] nvarchar(max)  NOT NULL,
    [geoLong] float  NOT NULL,
    [geoLat] float  NOT NULL,
    [adress] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [imagePath] nvarchar(max)  NOT NULL,
    [markerPath] nvarchar(max)  NOT NULL
);
GO


-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'MapLocationsSet'
ALTER TABLE [dbo].[MapLocationsSet]
ADD CONSTRAINT [PK_MapLocationsSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------