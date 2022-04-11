CREATE TABLE [dbo].[Dependents] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT          NOT NULL,
    [FirstName]  VARCHAR (50) NULL,
    [MiddleName] VARCHAR (50) NULL,
    [LastName]   VARCHAR (50) NULL,
    CONSTRAINT [PK_DependentId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Dependents_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id])
);



