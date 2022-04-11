CREATE PROCEDURE [dbo].[spInsertEmployeeSpouse] @employeeId INT	
	,@firstName VARCHAR(50)
	,@middleName VARCHAR(50)
	,@lastName VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Spouses (		
		FirstName
		,MiddleName
		,LastName
		)
	VALUES (		
		@firstName
		,@middleName
		,@lastName
		)

	UPDATE Employees
	SET SpouseId = SCOPE_IDENTITY()
	WHERE Id = @employeeId
END