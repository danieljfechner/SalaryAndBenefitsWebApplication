CREATE PROCEDURE [dbo].[spInsertEmployeeDependent] (
	@EmployeeId INT
	,@FirstName VARCHAR(50)
	,@MiddleName VARCHAR(50)
	,@LastName VARCHAR(50)
	)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Dependents (
		EmployeeId
		,FirstName
		,MiddleName
		,LastName
		)
	VALUES (
		@EmployeeId
		,@FirstName
		,@MiddleName
		,@LastName
		)
END