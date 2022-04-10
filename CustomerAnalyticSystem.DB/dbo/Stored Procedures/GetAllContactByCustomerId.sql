CREATE PROCEDURE [dbo].[GetAllContactByCustomerId]
	@Id integer
as
	select C.CustomerId, C.[Value], CT.[Name] from [dbo].[Contact] as C
	inner join ContactType as CT
	on C.ContactTypeId = CT.Id 
	where CustomerId = @Id and C.IsDeleted = 0 and CT.IsDeleted = 0

RETURN @Id
