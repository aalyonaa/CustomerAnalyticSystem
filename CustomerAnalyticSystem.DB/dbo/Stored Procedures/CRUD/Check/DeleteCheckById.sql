CREATE PROCEDURE [dbo].[DeleteCheckById]
	@Id integer
as
	update [dbo].[Check]
	set IsDeleted = 1
	where Id=@Id
