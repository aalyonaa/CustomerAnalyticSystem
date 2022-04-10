CREATE PROCEDURE [dbo].[DeletePreferenceById]
	@Id integer
as
update dbo.[Preferences]
set IsDeleted = 1
where Id=@Id
