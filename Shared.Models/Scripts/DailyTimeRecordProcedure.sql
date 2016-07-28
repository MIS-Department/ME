USE hr_bak
GO

CREATE PROCEDURE DailyTimeRecordInsert(
	@DailyTimeRecordId int OUTPUT,
	@EmployeeId int,
	@TimeCategoryId int,
	@DateCreated datetime,
	@Time datetime
)
AS
	SET NOCOUNT ON

	INSERT INTO dbo.DailyTimeRecord
	(
	    --DailyTimeRecordId - this column value is auto-generated
	    EmployeeId,
	    TimeCategoryId,
	    DateCreated,
	    [Time]
	)
	VALUES
	(
	    -- DailyTimeRecordId - int
	    @EmployeeId, -- EmployeeId - int
	    @TimeCategoryId, -- TimeCategoryId - int
	    @DateCreated, -- DateCreated - datetime
	    @Time-- Time - datetime
	)

	SET @DailyTimeRecordId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE DailyTimeRecordAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.DailyTimeRecord dtr
GO

CREATE PROCEDURE DailyTimeRecordUpdate(
	@DailyTimeRecordId int,
	@EmployeeId int,
	@TimeCategoryId int,
	@DateCreated datetime,
	@Time datetime
)
AS
	UPDATE dbo.DailyTimeRecord
	SET
	    --DailyTimeRecordId - this column value is auto-generated
	    dbo.DailyTimeRecord.EmployeeId = @EmployeeId, -- int
	    dbo.DailyTimeRecord.TimeCategoryId = @TimeCategoryId, -- int
	    dbo.DailyTimeRecord.DateCreated = @DateCreated, -- datetime
	    dbo.DailyTimeRecord.[Time] = @Time -- datetime
	WHERE DailyTimeRecordId = @DailyTimeRecordId
GO

CREATE PROCEDURE DailyTimeRecordDelete(
	@DailyTimeRecordId int,
	@EmployeeId int,
	@TimeCategoryId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.DailyTimeRecord
		WHERE DailyTimeRecordId = @DailyTimeRecordId AND
		EmployeeId = @EmployeeId AND
		TimeCategoryId = @TimeCategoryId
GO

CREATE PROCEDURE DailyTimeRecordSelectByEmployeeId(
	@EmployeeId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.DailyTimeRecord dtr
	WHERE EmployeeId = @EmployeeId
GO 

CREATE PROCEDURE DailyTimeRecordSelectById(
	@DailyTimeRecordId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM DailyTimeRecord
	WHERE DailyTimeRecordId = @DailyTimeRecordId
GO

CREATE PROCEDURE DailyTimeRecordEmployeeNumber(
	@EmployeeNumber int
)
AS
	SELECT e.employee_id, e.middleName, e.firstname, e.lastname, e.image_employee FROM dbo.employee e
	WHERE employee_number = @EmployeeNumber AND e.is_resigned = 0
GO
Create PROCEDURE [dbo].[DailyTimeRecordSelectByEmployeeIdDateCreated](
	@EmployeeId int,
	@StartDate datetime,
	@EndDate dateTime
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.DailyTimeRecord dtr
	WHERE EmployeeId = @EmployeeId  AND DateCreated BETWEEN @StartDate AND @EndDate
GO
