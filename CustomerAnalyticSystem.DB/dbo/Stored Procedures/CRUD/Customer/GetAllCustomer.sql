CREATE PROCEDURE [dbo].[GetAllCustomer]
as
	select C.Id, C.FirstName, C.LastName, C.TypeId from [dbo].[Customer] as C
	where IsDeleted = 0