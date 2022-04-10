CREATE PROCEDURE [dbo].[GetAllContactWithContactTypeByCustomerId]
	@Id integer
AS
	select C.Id, CT.[Name] as ContactTypeName, C.[Value] from ContactType as CT
	left join Contact as C
	on C.ContactTypeId = CT.Id
	where C.CustomerId = @Id and C.IsDeleted = 0 and CT.IsDeleted = 0
return @Id