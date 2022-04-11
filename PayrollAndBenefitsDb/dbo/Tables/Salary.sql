CREATE TABLE [dbo].[Salary] (
    [SalaryId]     INT   IDENTITY (1, 1) NOT NULL,
    [EmployeeId]   INT   NOT NULL,
    [SalaryAmount] MONEY NULL,
    CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED ([SalaryId] ASC),
    CONSTRAINT [FK_Salary_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id])
);

