using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Models
{
    public class GroupsWithProductsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductBaseModel> Products { get; set; }
    }
}
