namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CustomersOrderDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderId { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }

    }
}
