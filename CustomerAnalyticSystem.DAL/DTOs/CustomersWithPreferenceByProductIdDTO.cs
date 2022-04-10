namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CustomersWithPreferenceByProductIdDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeId { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public int GroupId { get; set; }
        public bool IsInterested { get; set; }

    }
}
