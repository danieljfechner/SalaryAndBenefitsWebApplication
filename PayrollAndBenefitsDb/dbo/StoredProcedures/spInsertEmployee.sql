CREATE PROCEDURE [dbo].[spInsertEmployee] @firstName VARCHAR(50)
	,@middleName VARCHAR(50)
	,@lastName VARCHAR(50)
	,@Id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Employees (
		FirstName
		,MiddleName
		,LastName
		,Salary
		)	
	VALUES (
		@firstName
		,@middleName
		,@lastName
		,2000
		)
	SET @Id = SCOPE_IDENTITY()			
END