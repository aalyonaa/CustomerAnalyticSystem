CREATE PROCEDURE [dbo].[GetAllStatus]
	as
	select S.[Id], S.[Name] from [dbo].[Status] as S
	where IsDeleted = 0
	
RETURN 0
