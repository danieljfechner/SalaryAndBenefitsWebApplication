CREATE PROCEDURE [dbo].[spGetEmployeeWithSpouseAndSalaryByEmployeeId]
	@employeeId int
AS
begin
	SELECT e.Id
		,e.FirstName
		,e.MiddleName
		,e.LastName
		,sp.FirstName AS SpouseFirstName
		,e.MiddleName AS SpouseMiddleName
		,sp.LastName AS SpouseLastName
		,e.Salary
	FROM dbo.Employees e
	LEFT JOIN Spouses sp ON e.SpouseId = sp.Id
	WHERE e.Id = @employeeId
end