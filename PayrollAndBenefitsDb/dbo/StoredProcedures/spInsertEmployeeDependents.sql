CREATE PROCEDURE [dbo].[spInsertEmployeeDependents] @employeeDependents EmployeeDependents readonly
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Dependents (
		EmployeeId
		,FirstName
		,MiddleName
		,LastName
		)
	SELECT EmployeeId
		,FirstName
		,MiddleName
		,LastName
	FROM @employeeDependents
END