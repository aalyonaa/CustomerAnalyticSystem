using CustomerAnalyticSystem.BLL.Models;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{
    public class StackModel
    {
        public List<ProductBaseModel> Products { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<GroupBaseModel> Groups { get; set; }

        public List<ProductTagBaseModel> Product_Tag { get; set; }

        public List<OrderBaseModel> Orders { get; set; }
        public List<CheckBaseModel> Checks { get; set; }

        public List<GradeBaseModel> Grades { get; set; }
    }
}
