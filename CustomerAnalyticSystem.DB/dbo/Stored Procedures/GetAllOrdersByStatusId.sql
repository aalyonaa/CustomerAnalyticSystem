CREATE PROCEDURE [dbo].[GetAllOrdersByStatusId]
@Id integer
as
select O.[Id], O.[Date], O.[CustomerId], Cust.[FirstName], Cust.[LastName], S.[Name] as "Status", O.[Cost] from [dbo].[Order] as O
join [dbo].[Customer] as Cust
	on Cust.Id = O.CustomerId
join [dbo].[Status] as S
	on S.Id = O.StatusId
	where O.StatusId = @Id
RETURN 0
