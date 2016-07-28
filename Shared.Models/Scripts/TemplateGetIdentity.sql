USE hr_bak
GO

ALTER PROCEDURE TemplateGetIdentity(
	@TemplateId int OUTPUT
)
AS
	SET NOCOUNT ON

	SET @TemplateId = IDENT_CURRENT('Template')
GO

DECLARE @Template int

EXECUTE TemplateGetIdentity @TemplateId = @Template output
