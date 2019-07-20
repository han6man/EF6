
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/02/2019 11:02:54
-- Generated from EDMX file: C:\Users\Evgeny\source\repos\EF6\IsraelGeoDataModelFirst\IsraelGeoDataDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IsraelGeoDataTemp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LishkotMana'
CREATE TABLE [dbo].[LishkotMana] (
    [lishkat_mana_code] int IDENTITY(1,1) NOT NULL,
    [lishka] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Muacot'
CREATE TABLE [dbo].[Muacot] (
    [muaca_ezorit_code] int IDENTITY(1,1) NOT NULL,
    [muaca_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [city_code] int IDENTITY(1,1) NOT NULL,
    [city_name] nvarchar(50)  NOT NULL,
    [city_name_foreign] nvarchar(50)  NULL,
    [region_code] int  NULL,
    [lishkat_mana_code] int  NULL,
    [muaca_ezorit_code] int  NULL
);
GO

-- Creating table 'Streets'
CREATE TABLE [dbo].[Streets] (
    [street_code] int IDENTITY(1,1) NOT NULL,
    [street_name] nvarchar(50)  NOT NULL,
    [street_name_status] nvarchar(50)  NOT NULL,
    [official_code] int  NOT NULL,
    [city_code] int  NOT NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [region_code] int IDENTITY(1,1) NOT NULL,
    [region_name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [lishkat_mana_code] in table 'LishkotMana'
ALTER TABLE [dbo].[LishkotMana]
ADD CONSTRAINT [PK_LishkotMana]
    PRIMARY KEY CLUSTERED ([lishkat_mana_code] ASC);
GO

-- Creating primary key on [muaca_ezorit_code] in table 'Muacot'
ALTER TABLE [dbo].[Muacot]
ADD CONSTRAINT [PK_Muacot]
    PRIMARY KEY CLUSTERED ([muaca_ezorit_code] ASC);
GO

-- Creating primary key on [city_code] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([city_code] ASC);
GO

-- Creating primary key on [street_code] in table 'Streets'
ALTER TABLE [dbo].[Streets]
ADD CONSTRAINT [PK_Streets]
    PRIMARY KEY CLUSTERED ([street_code] ASC);
GO

-- Creating primary key on [region_code] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([region_code] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [lishkat_mana_code] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_dbo_Cities_dbo_LishkotMana_lishkat_mana_code]
    FOREIGN KEY ([lishkat_mana_code])
    REFERENCES [dbo].[LishkotMana]
        ([lishkat_mana_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Cities_dbo_LishkotMana_lishkat_mana_code'
CREATE INDEX [IX_FK_dbo_Cities_dbo_LishkotMana_lishkat_mana_code]
ON [dbo].[Cities]
    ([lishkat_mana_code]);
GO

-- Creating foreign key on [muaca_ezorit_code] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_dbo_Cities_dbo_Muacot_muaca_ezorit_code]
    FOREIGN KEY ([muaca_ezorit_code])
    REFERENCES [dbo].[Muacot]
        ([muaca_ezorit_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Cities_dbo_Muacot_muaca_ezorit_code'
CREATE INDEX [IX_FK_dbo_Cities_dbo_Muacot_muaca_ezorit_code]
ON [dbo].[Cities]
    ([muaca_ezorit_code]);
GO

-- Creating foreign key on [region_code] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_RegionCity]
    FOREIGN KEY ([region_code])
    REFERENCES [dbo].[Regions]
        ([region_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionCity'
CREATE INDEX [IX_FK_RegionCity]
ON [dbo].[Cities]
    ([region_code]);
GO

-- Creating foreign key on [city_code] in table 'Streets'
ALTER TABLE [dbo].[Streets]
ADD CONSTRAINT [FK_CityStreet]
    FOREIGN KEY ([city_code])
    REFERENCES [dbo].[Cities]
        ([city_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityStreet'
CREATE INDEX [IX_FK_CityStreet]
ON [dbo].[Streets]
    ([city_code]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------