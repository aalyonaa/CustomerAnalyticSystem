using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Analytics
{
    public class DataAnaliseModel
    {
        public List<PreferencesByCustomerIdModel> AllCustomers { get; set; }
        public List<ProductWithCustomerPreferences> AllProducts { get; set; }

    }
}
