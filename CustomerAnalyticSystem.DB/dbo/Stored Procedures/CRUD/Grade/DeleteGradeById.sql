CREATE PROCEDURE [dbo].[DeleteGradeById]
	@Id integer
as
update dbo.[Grade]
set IsDeleted = 1
where Id=@Id
