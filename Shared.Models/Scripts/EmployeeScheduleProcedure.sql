USE hr_bak
GO

CREATE PROCEDURE EmployeeScheduleInsert(
	@EmployeeScheduleId int OUTPUT,
	@EmployeeId int,
	@ScheduleId int,
	@Date date
)
AS
	SET NOCOUNT ON

	INSERT INTO dbo.EmployeeSchedule
	(
	    --EmployeeScheduleId - this column value is auto-generated
	    EmployeeId,
	    ScheduleId,
	    [Date]
	)
	VALUES
	(
	    -- EmployeeScheduleId - int
	    @EmployeeId, -- EmployeeId - int
	    @ScheduleId, -- ScheduleId - int
	    @Date -- Date - date
	)

	SET @EmployeeScheduleId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE EmployeeScheduleSelectById(
	@EmployeeScheduleId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.EmployeeSchedule es
	WHERE EmployeeScheduleId = @EmployeeScheduleId
GO

CREATE PROCEDURE EmployeeScheduleAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.EmployeeSchedule es
GO

CREATE PROCEDURE EmployeeScheduleUpdate(
	@EmployeeScheduleId int,
	@EmployeeId int,
	@ScheduleId int,
	@Date date
)
AS
	SET NOCOUNT ON

	UPDATE dbo.EmployeeSchedule
	SET
	    --EmployeeScheduleId - this column value is auto-generated
	    dbo.EmployeeSchedule.EmployeeId = @EmployeeId, -- int
	    dbo.EmployeeSchedule.ScheduleId = @ScheduleId, -- int
	    dbo.EmployeeSchedule.[Date] = @Date -- date
	WHERE EmployeeScheduleId = @EmployeeScheduleId
GO 

CREATE PROCEDURE EmployeeScheduleDelete(
	@EmployeeScheduleId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.EmployeeSchedule
	WHERE EmployeeScheduleId = @EmployeeScheduleId
GO

CREATE PROCEDURE EmployeeScheduleSelectByDate(
	@StartDate date,
	@EndDate date
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.EmployeeSchedule es
	WHERE es.Date BETWEEN @StartDate AND @EndDate
GO 

CREATE PROCEDURE EmployeeScheduleSelectByEmployee(
	@EmployeeId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.EmployeeSchedule es
	WHERE EmployeeId = @EmployeeId
GO 

CREATE PROCEDURE EmployeeScheduleSelectByScheduleId(
	@ScheduleId int
)
AS 
	SET NOCOUNT ON

	SELECT * FROM dbo.EmployeeSchedule es
	WHERE es.ScheduleId = @ScheduleId 
GO 