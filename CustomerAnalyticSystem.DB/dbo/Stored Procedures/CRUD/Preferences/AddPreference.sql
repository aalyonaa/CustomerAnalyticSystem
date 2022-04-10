CREATE PROCEDURE [dbo].[AddPreference]
	@ProductId integer, @CustomerId integer, @TagId integer, @GroupId integer, @IsInterested bit
as
insert into [dbo].[Preferences]
values (@ProductId, @CustomerId, @TagId, @GroupId, @IsInterested, 0)
