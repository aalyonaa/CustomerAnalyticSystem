CREATE PROCEDURE [dbo].[GetAllComment]
	as
	select C.[Id], C.[CustomerId], C.[Text] as TempId
	from [dbo].[Comment] as C
	where C.IsDeleted = 0