using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{
    public class ConcreteProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public List<string> Groups { get; set; }
        public List<string> Tags { get; set; }
        public List<ConcreteCustomer> Customers { get; set; }


        public int Percent { get; set; }
        public int AverageMark { get; set; }
    }
}
