CREATE PROCEDURE [dbo].[UpdateContact]
	@Id integer,
	@CustomerId integer,
	@ContactTypeId integer,
	@Value nvarchar (255)
as
update dbo.[Contact]
set Value = @Value,
ContactTypeId = @ContactTypeId,
CustomerId = @CustomerId
where Id = @Id
RETURN 0
