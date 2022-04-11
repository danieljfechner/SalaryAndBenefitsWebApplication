CREATE TABLE [dbo].[Employees] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (50) NULL,
    [MiddleName] VARCHAR (50) NULL,
    [LastName]   VARCHAR (50) NULL,
    [SpouseId]   INT          NULL,
    [Salary]     MONEY        NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employees_Spouse] FOREIGN KEY ([SpouseId]) REFERENCES [dbo].[Spouses] ([Id])
);



