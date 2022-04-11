CREATE TABLE [dbo].[Spouses] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]           VARCHAR (50) NULL,
    [MiddleName]          VARCHAR (50) NULL,
    [LastName]            VARCHAR (50) NULL,
    CONSTRAINT [PK_Spouse] PRIMARY KEY CLUSTERED ([Id] ASC)
);



