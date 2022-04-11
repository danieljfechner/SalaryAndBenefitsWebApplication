CREATE TYPE [dbo].[EmployeeDependents] AS TABLE (
    [EmployeeId] INT          NOT NULL,
    [FirstName]  VARCHAR (50) NULL,
    [MiddleName] VARCHAR (50) NULL,
    [LastName]   VARCHAR (50) NULL);

