CREATE PROCEDURE [dbo].[GetAllCustomerWithContactAndContactType]
AS
	select C.Id, C.FirstName, C.LastName, CT.[Name], Con.Id, ConT.[Name] as ContactTypeName, Con.[Value]
		from [dbo].[Customer] as C
	left join [dbo].[CustomerType] as CT
	on C.TypeId = CT.Id and CT.IsDeleted = 0
	left join [dbo].[Contact] as Con
	on Con.CustomerId = C.Id and Con.IsDeleted = 0
	left join [dbo].[ContactType] as ConT
	on ConT.Id = Con.ContactTypeId and ConT.IsDeleted = 0
	where C.IsDeleted = 0 
	order by C.Id
RETURN 0