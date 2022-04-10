namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class GetOrderModelDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public int Cost { get; set; }
    }
}
