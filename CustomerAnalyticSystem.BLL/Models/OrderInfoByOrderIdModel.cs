using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Models
{
    public class OrderInfoByOrderIdModel
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public List<CheckBaseModel> Items { get; set; }
    }
}
