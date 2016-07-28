USE hr_bak
GO

CREATE PROCEDURE TimeCategorySelectAll
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TimeCategory tc
GO

CREATE PROCEDURE TimeCategorySelectById(
	@TimeCategoryId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TimeCategory tc
	WHERE TimeCategoryId = @TimeCategoryId
GO

CREATE PROCEDURE TimeCategorySelectByValue(
	@TimeCategoryValue varchar(25)
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TimeCategory tc
	WHERE TimeCategoryValue = @TimeCategoryValue
GO

CREATE PROCEDURE TimeCategoryInsert(
	@TimeCategoryId int OUTPUT,
	@TimeCategoryValue varchar(25)
)
AS
	SET NOCOUNT ON

	INSERT INTO dbo.TimeCategory
	(
	    --TimeCategoryId - this column value is auto-generated
	    TimeCategoryValue
	)
	VALUES
	(
	    -- TimeCategoryId - int
	    @TimeCategoryValue -- TimeCategoryValue - varchar
	)

	SET @TimeCategoryId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE TimeCategoryDelete(
	@TimeCategoryId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.TimeCategory
	WHERE TimeCategoryId = @TimeCategoryId
GO

CREATE PROCEDURE TimeCategoryUpdate(
	@TimeCategoryId int,
	@TimeCategoryValue varchar(25)
)
AS
	SET NOCOUNT ON

	UPDATE dbo.TimeCategory
	SET
	    --TimeCategoryId - this column value is auto-generated
	    dbo.TimeCategory.TimeCategoryValue = @TimeCategoryValue -- varchar
	WHERE TimeCategoryId = @TimeCategoryId
GO


