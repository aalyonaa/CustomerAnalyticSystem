namespace CustomerAnalyticSystem.DAL.Interfaces
{
    public interface IBaseCustomer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeId { get; set; }
    }
}
