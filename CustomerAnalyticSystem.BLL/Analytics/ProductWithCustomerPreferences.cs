using CustomerAnalyticSystem.BLL.Models;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Analytics
{
    public class ProductWithCustomerPreferences : ProductBaseModel
    {
        public int ProductId { get; set; }
        public List<CustomerModel> Customers { get; set; }
    }
}
