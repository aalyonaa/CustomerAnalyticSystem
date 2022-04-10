using CustomerAnalyticSystem.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAnalyticSystem.DAL.RepInterfaces
{
    public interface IOrderRepository
    {
        public List<StatusDTO> GetAllStatus();
        public void AddStatus(string Name);
        public void DeleteStatusById(int id);
        public void UpdateStatusById(int id, string name);
        public List<GetOrderModelDTO> GetAllOrdersByStatusId(int id);
        public List<CheckByOrderIdDTO> GetCheckByOrderId(int id);



    }
}
