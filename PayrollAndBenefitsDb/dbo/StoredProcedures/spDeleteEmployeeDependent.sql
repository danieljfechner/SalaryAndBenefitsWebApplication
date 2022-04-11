CREATE PROCEDURE [dbo].[spDeleteEmployeeDependent] @dependentId INT
AS
BEGIN
	DELETE d
	FROM Dependents d
	WHERE d.Id = @dependentId
END