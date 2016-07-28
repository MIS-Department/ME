USE hr_bak
GO

CREATE PROCEDURE TimeTypeSelectAll
AS
	SET NOCOUNT ON

	SELECT * FROM TimeType
GO

CREATE PROCEDURE TimeTypeSelectById(
	@TimeTypeId int
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TimeType tt
	WHERE tt.TimeTypeId = @TimeTypeId
GO

CREATE PROCEDURE TimeTypeSelectByName(
	@Name varchar(25)
)
AS
	SET NOCOUNT ON

	SELECT * FROM dbo.TimeType tt
	WHERE tt.Name = @Name
GO

CREATE PROCEDURE TimeTypeInsert(
	@TimeTypeId int OUTPUT,
	@Name varchar(25)
)
AS
	SET NOCOUNT ON


	INSERT INTO dbo.TimeType
	(
	    --TimeTypeId - this column value is auto-generated
	    Name
	)
	VALUES
	(
	    -- TimeTypeId - int
	    @Name -- Name - varchar
	)

	SET @TimeTypeId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE TimeTypeDelete(
	@TimeTypeId int
)
AS
	SET NOCOUNT ON

	DELETE FROM dbo.TimeType WHERE TimeTypeId = @TimeTypeId
GO

CREATE PROCEDURE TimeTypeUpdate(
	@TimeTypeId int,
	@Name varchar(25)
)
AS
	SET NOCOUNT ON

	UPDATE dbo.TimeType
	SET
	    --TimeTypeId - this column value is auto-generated
	    dbo.TimeType.Name = @Name -- varchar
	WHERE TimeTypeId = @TimeTypeId
GO
