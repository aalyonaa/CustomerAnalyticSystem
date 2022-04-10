using CustomerAnalyticSystem.DAL.Interfaces;
namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CheckWithCustomerInfoDTO : CheckDTO, IBaseCustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeId { get; set; }
    }
}
