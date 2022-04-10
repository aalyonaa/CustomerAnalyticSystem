CREATE PROCEDURE [dbo].[DeleteContact]
@Id integer
as
update dbo.[Contact]
set IsDeleted = 1
where Id = @Id