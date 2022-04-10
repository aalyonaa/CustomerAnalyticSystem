CREATE PROCEDURE [dbo].[AddGrade]
	@ProductId integer, @CustomerId integer, @Value integer
as
insert into [dbo].[Grade]
values (@ProductId, @CustomerId, @Value, 0)
