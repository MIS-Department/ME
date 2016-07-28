USE hr_bak
GO

CREATE PROCEDURE TemplateScheduleAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TemplateSchedule ts
GO 

CREATE PROCEDURE TemplateScheduleSelectByTemplateScheduleId(
	@TemplateScheduleId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM TemplateSchedule WHERE TemplateScheduleId = @TemplateScheduleId
GO 

CREATE PROCEDURE TemplateScheduleInsert(
	@TemplateScheduleId int OUTPUT,
	@ScheduleId int,
	@TemplateId int
)
AS
	SET NOCOUNT ON

	INSERT INTO dbo.TemplateSchedule
	(
	    --TemplateScheduleId - this column value is auto-generated
	    ScheduleId,
	    TemplateId
	)
	VALUES
	(
	    -- TemplateScheduleId - int
	    @ScheduleId, -- ScheduleId - int
	    @TemplateId -- TemplateId - int
	)

	SET @TemplateScheduleId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE TemplateScheduleUpdate(
	@TemplateScheduleId int,
	@ScheduleId int,
	@TemplateId int
)
AS
	SET NOCOUNT ON

	UPDATE dbo.TemplateSchedule
	SET
	    --TemplateScheduleId - this column value is auto-generated
	    dbo.TemplateSchedule.ScheduleId = @ScheduleId, -- int
	    dbo.TemplateSchedule.TemplateId = @TemplateId -- int
	WHERE TemplateScheduleId = @TemplateScheduleId
GO

CREATE PROCEDURE TemplateScheduleDelete(
	@TemplateScheduleId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.TemplateSchedule WHERE TemplateScheduleId = @TemplateScheduleId
GO 

CREATE PROCEDURE TemplateScheduleSelectByScheduleId(
	@ScheduleId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM TemplateSchedule WHERE ScheduleId = @ScheduleId
GO
