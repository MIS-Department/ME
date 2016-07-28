USE hr_bak
GO

CREATE PROCEDURE ScheduleAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.ScheduleNew sn
GO

CREATE PROCEDURE ScheduleSelectByName(
	@Name varchar(25)
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.ScheduleNew sn
	WHERE Name = @Name
GO

CREATE PROCEDURE ScheduleUpdate(
	@ScheduleId int,
	@Name varchar(25)
)
AS
	SET NOCOUNT ON

	UPDATE dbo.ScheduleNew
	SET
	    --ScheduleId - this column value is auto-generated
	    dbo.ScheduleNew.Name = @Name -- varchar
	WHERE ScheduleId = @ScheduleId
GO 

CREATE PROCEDURE ScheduleInsert(
	@ScheduleId int OUTPUT
	,@Name varchar(25)
)
AS
	SET NOCOUNT ON

	INSERT dbo.ScheduleNew
	(
	    --ScheduleId - this column value is auto-generated
	    Name
	)
	VALUES
	(
	    -- ScheduleId - int
	    @Name -- Name - varchar
	)

	SET @ScheduleId = SCOPE_IDENTITY();
GO 

CREATE PROCEDURE ScheduleDelete(
	@ScheduleId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.ScheduleNew
	WHERE ScheduleId = @ScheduleId
GO

CREATE PROCEDURE ScheduleSelectById(
	@ScheduleId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM ScheduleNew
	WHERE ScheduleId = @ScheduleId
GO
