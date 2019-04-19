
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2019 15:06:10
-- Generated from EDMX file: E:\ADLCPRo\FSTA\FSTA\Models\FourSTA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FourSTA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PackagePackageDetailsDAO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PackageDetailsDAOs] DROP CONSTRAINT [FK_PackagePackageDetailsDAO];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PackageDetailsDAOs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PackageDetailsDAOs];
GO
IF OBJECT_ID(N'[dbo].[Packages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Packages];
GO
IF OBJECT_ID(N'[dbo].[TourLeaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TourLeaders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PackageDetailsDAOs'
CREATE TABLE [dbo].[PackageDetailsDAOs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PackageName] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [TourLeaderName] nvarchar(max)  NOT NULL,
    [Package_id] int  NOT NULL
);
GO

-- Creating table 'Packages'
CREATE TABLE [dbo].[Packages] (
    [id] int IDENTITY(1,1) NOT NULL,
    [PackageName] nvarchar(50)  NOT NULL,
    [PackageDesc] nvarchar(50)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Duration] int  NOT NULL,
    [PackageDetailsDAOId] int  NOT NULL
);
GO

-- Creating table 'TourLeaders'
CREATE TABLE [dbo].[TourLeaders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Salary] decimal(18,2)  NOT NULL,
    [Rank] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PackageDetailsDAOs'
ALTER TABLE [dbo].[PackageDetailsDAOs]
ADD CONSTRAINT [PK_PackageDetailsDAOs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [PK_Packages]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TourLeaders'
ALTER TABLE [dbo].[TourLeaders]
ADD CONSTRAINT [PK_TourLeaders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PackageDetailsDAOId] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [FK_PackageDetailsDAOPackage]
    FOREIGN KEY ([PackageDetailsDAOId])
    REFERENCES [dbo].[PackageDetailsDAOs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PackageDetailsDAOPackage'
CREATE INDEX [IX_FK_PackageDetailsDAOPackage]
ON [dbo].[Packages]
    ([PackageDetailsDAOId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------