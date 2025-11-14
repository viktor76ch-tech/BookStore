CREATE TABLE [dbo].[Books] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [LastName]          NVARCHAR (50) NOT NULL,
    [FirstName]         NVARCHAR (50) NOT NULL,
    [Genre]         NVARCHAR (50) NOT NULL,
    [Publisher]         NVARCHAR (50) NOT NULL,
    [YearPub]      INT           DEFAULT ((1)) NOT NULL,
    [Pages]      INT           DEFAULT ((1)) NOT NULL,
    [CostPrice]      FLOAT            NOT NULL,
    [Price]      FLOAT            NOT NULL,
    [Number]      INT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);