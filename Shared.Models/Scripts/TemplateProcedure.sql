USE hr_bak
GO

CREATE PROCEDURE TemplateInsert(
	@TemplateId int OUTPUT,
	@TemplateCode nvarchar(50),
	@Description nvarchar(50),
	@Start time,
	@End time
)
AS
	SET NOCOUNT ON

	INSERT INTO dbo.Template
	(
	    --TemplateId - this column value is auto-generated
	    TemplateCode,
	    Description,
	    StartTime,
	    EndTime
	)
	VALUES
	(
	    -- TemplateId - int
	    @TemplateCode, -- TemplateCode - nvarchar
	    @Description, -- Description - nvarchar
	    @Start, -- StartTime - time
	    @End -- EndTime - time
	)

	SET @TemplateId = SCOPE_IDENTITY();
GO 

CREATE PROCEDURE TemplateSelectById(
	@TemplateId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.Template t
	WHERE TemplateId = @TemplateId
GO 

CREATE PROCEDURE TemplateSelectByDescription(
	@Description nvarchar(50)
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.Template t
	WHERE t.Description LIKE '%' + @Description + '%'
GO


CREATE PROCEDURE TemplateSelectAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.Template t
GO

CREATE PROCEDURE TemplateUpdate(
	@TemplateId int,
	@Description nvarchar(50),
	@Start time,
	@End time
)
AS
	SET NOCOUNT ON

	UPDATE dbo.Template
	SET
	    --TemplateId - this column value is auto-generated
	    dbo.Template.Description = @Description, -- nvarchar
	    dbo.Template.StartTime = @Start, -- time
	    dbo.Template.EndTime = @End -- time
	WHERE TemplateId = @TemplateId
GO 

CREATE PROCEDURE TemplateDelete(
	@TemplateId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.Template
	WHERE TemplateId = @TemplateId
GO 

CREATE PROCEDURE SelectByStartEnd(
	@Start time,
	@End time
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.Template t
	WHERE t.StartTime LIKE @start AND t.EndTime LIKE @End
GO 