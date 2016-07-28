USE hr_bak
GO

CREATE PROCEDURE CalculatedTimeAll
AS
	SET NOCOUNT ON 

	SELECT * FROM CalculatedTime
GO

CREATE PROCEDURE CalculatedTimeSelectById(
	@CalculatedTimeId int
)
AS
	SELECT * FROM CalculatedTime WHERE CalculatedTimeId = @CalculatedTimeId
GO

CREATE PROCEDURE CalculatedTimeInsert(
	@CalculatedId int OUTPUT,
	@TimeTypeId int,
	@Value time,
	@DailyTimeRecordId int
)
AS
	INSERT INTO dbo.CalculatedTime
	(
	    --CalculatedTimeId - this column value is auto-generated
	    TimeTypeId,
	    [Value],
	    DailyTimeRecordId
	)
	VALUES
	(
	    -- CalculatedTimeId - int
	    @TimeTypeId, -- TimeTypeId - int
	    @Value, -- Value - time
	    @DailyTimeRecordId-- DailyTimeRecordId - int
	)

	SET @CalculatedId = SCOPE_IDENTITY();
GO 

CREATE PROCEDURE CalculatedTimeSelectByDailyTimeRecordId(
	@DailyTimeRecordId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM CalculatedTime WHERE DailyTimeRecordId = @DailyTimeRecordId
GO 

CREATE PROCEDURE CalculatedTimeDelete(
	@CalculatedTimeId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.CalculatedTime
	WHERE CalculatedTimeId = @CalculatedTimeId
GO


CREATE PROCEDURE CalculatedTimeUpdate(
	@CalculatedTimeId int,
	@TimeTypeId int,
	@Value time,
	@DailyTimeRecordId int
)
AS
	SET NOCOUNT ON

	UPDATE dbo.CalculatedTime
	SET
	    --CalculatedTimeId - this column value is auto-generated
	    dbo.CalculatedTime.TimeTypeId = @TimeTypeId, -- int
	    dbo.CalculatedTime.[Value] = @Value, -- time
	    dbo.CalculatedTime.DailyTimeRecordId = @DailyTimeRecordId -- int
	WHERE CalculatedTimeId = @CalculatedTimeId
GO