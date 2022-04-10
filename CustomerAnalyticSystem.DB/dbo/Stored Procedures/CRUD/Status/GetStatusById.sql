CREATE PROCEDURE [dbo].[GetStatusById]
	@Id integer 
AS
	select S.[Id], S.[Name] from [dbo].[Status] as S
	where Id = @Id and IsDeleted = 0
RETURN @Id
