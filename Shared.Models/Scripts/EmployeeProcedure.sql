USE hr_bak
GO

CREATE PROCEDURE EmployeeSelectAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.employee e
GO

CREATE PROCEDURE [dbo].[EmployeeSelectByEmployeeNumber](
@EmployeeNumber varchar(25)
)
AS


SET NOCOUNT ON


SELECT * FROM employee 
WHERE employee.employee_number LIKE @EmployeeNumber

GO

CREATE PROCEDURE [dbo].[EmployeeSelectByID](
@EmployeeId int
)
AS


SET NOCOUNT ON


SELECT * FROM employee 
WHERE employee.employee_number LIKE @EmployeeId

GO
---error here




