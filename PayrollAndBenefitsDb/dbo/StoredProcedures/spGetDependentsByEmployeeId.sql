CREATE PROCEDURE [dbo].[spGetDependentsByEmployeeId] @employeeId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id
		,EmployeeId
		,FirstName
		,MiddleName
		,LastName
	FROM [dbo].[Dependents]
	WHERE EmployeeId = @employeeId
END
GO