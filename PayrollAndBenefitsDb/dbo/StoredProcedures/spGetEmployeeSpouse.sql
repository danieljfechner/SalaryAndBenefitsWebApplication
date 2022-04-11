CREATE PROCEDURE [dbo].[spGetEmployeeSpouse] @employeeId INT
AS
BEGIN
	SELECT sp.Id
		,sp.FirstName
		,sp.MiddleName
		,sp.LastName
	FROM Spouses sp
	JOIN Employees e ON e.SpouseId = sp.Id
	WHERE e.Id = @employeeId
END