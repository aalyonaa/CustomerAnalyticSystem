using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL;

namespace CustomerAnalyticSystem.BLL.Services
{
    public class OrderInfoByOrderIdService
    {
        public OrderInfoByOrderIdModel GetOrderInfoByOrderId(int id)
        {
            BestMapper map = new();
            var service = new OrderRepository();
            var dto = service.FillOrderInfoByOrderId(id);
            OrderInfoByOrderIdModel result = map.MapOrderInfoByOrderId(dto);
            return result;
        }


    }
}
