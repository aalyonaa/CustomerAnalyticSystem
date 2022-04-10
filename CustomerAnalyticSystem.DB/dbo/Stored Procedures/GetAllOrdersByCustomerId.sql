CREATE PROCEDURE [dbo].[GetAllOrdersByCustomerId]
	@Id integer
	as
	select Cus.Id, Cus.FirstName, Cus.LastName, O.Id as 'OrderId', O.[Date], 
	C.Amount from [dbo].[Check] as C
	join [dbo].[Order] as O
	on C.OrderId = O.Id
	join [dbo].[Customer] as Cus
	on O.CustomerId = Cus.Id
	where Cus.Id = @Id and C.IsDeleted = 0 and O.IsDeleted = 0 and Cus.IsDeleted = 0
RETURN 0