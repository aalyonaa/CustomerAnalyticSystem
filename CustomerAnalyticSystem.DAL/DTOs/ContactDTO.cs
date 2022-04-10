namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }
    }
}
