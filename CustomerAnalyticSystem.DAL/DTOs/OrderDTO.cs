namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public string StatusId { get; set; }
        public int Cost { get; set; }
    }
}
