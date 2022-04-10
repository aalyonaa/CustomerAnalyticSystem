CREATE PROCEDURE [dbo].[GetAllCustomerType]
AS
	select CT.Id, CT.[Name] from [dbo].[CustomerType] as CT
	where IsDeleted = 0