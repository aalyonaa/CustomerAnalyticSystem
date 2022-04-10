using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CustomerAnalyticSystem.DAL
{
    public class OrderRepository : IOrderRepository
    {
        public List<OrderDTO> GetAllOrders()
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                orders = connection.Query<OrderDTO>(Queries.GetAllOrders).ToList();
            }
            return orders;
        }

        public OrderDTO GetOrderById(int id)
        {
            OrderDTO order;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                order = connection.QuerySingle<OrderDTO>(Queries.GetOrderById, new { id }
               , commandType: CommandType.StoredProcedure);
            }
            return order;
        }

        public void AddOrder(int CustomerId, string Date, int StatusId, int Cost)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<OrderDTO>(Queries.AddOrder, new { CustomerId, Date, StatusId, Cost }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteOrderById(int id)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<OrderDTO>(Queries.DeleteOrderById, new { id }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateOrderById(int id, int CustomerId, string Date, int StatusId, int Cost)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<GradeDTO>(Queries.UpdateOrderById, new { id, CustomerId, Date, StatusId, Cost }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public List<StatusDTO> GetAllStatus()
        {
            List<StatusDTO> status = new List<StatusDTO>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                status = connection.Query<StatusDTO>(Queries.GetAllStatus).ToList();
            }
            return status;
        }

        public StatusDTO GetStatusById(int id)
        {
            StatusDTO status;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                status = connection.QuerySingle<StatusDTO>(Queries.GetStatusById, new { id }
               , commandType: CommandType.StoredProcedure);
            }
            return status;
        }

        public void AddStatus(string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<StatusDTO>(Queries.AddStatus, new { Name }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteStatusById(int id)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<StatusDTO>(Queries.DeleteStatusById, new { id }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateStatusById(int id, string Name)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<StatusDTO>(Queries.UpdateStatusById, new { id, Name }
                , commandType: CommandType.StoredProcedure);
            }
        }


        #region Group
        public void AddGroup(string name, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<GroupBaseDTO>(Queries.AddGroup, new { name, description }
                , commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
        public List<CheckDTO> GetAllCheck()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CheckDTO>(Queries.GetAllCheck, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CheckDTO GetCheckById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.QuerySingle<CheckDTO>(Queries.GetCheckById, new { id },
                commandType: CommandType.StoredProcedure);
            }

        }

        public void AddCheck(int ProductId, int OrderId, int Amount, int Mark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<CheckDTO>(Queries.AddCheck, new { ProductId, OrderId, Amount, Mark },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCheck(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<CheckDTO>(Queries.DeleteCheck, new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCheck(int id, int ProductId, int OrderId, int Amount, int Mark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<CheckDTO>(Queries.UpdateCheck, new { id, ProductId, OrderId, Amount, Mark },
                commandType: CommandType.StoredProcedure);
            }
        }

        public AllOrderInfoByOrderId FillOrderInfoByOrderId(int id)
        {
            AllOrderInfoByOrderId concreteOrder = null;

            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query<AllOrderInfoByOrderId, CheckDTO, AllOrderInfoByOrderId>(Queries.GetAllOrderInfoByOrderId,
                    (orderInfo, item) =>
                {
                    if (concreteOrder == null)
                    {
                        concreteOrder = orderInfo;
                        concreteOrder.Items = new();
                    }
                    concreteOrder.Items.Add(item);
                    return concreteOrder;
                }
                , new { Id = id }
                , commandType: CommandType.StoredProcedure
                , splitOn: "OrderId,Id");
            }
            return concreteOrder;
        }

        public List<CustomersOrderDTO> GetAllOrdersByCustomerId(int id)
        {
            List<CustomersOrderDTO> customersOrderDTOs = new List<CustomersOrderDTO>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                customersOrderDTOs = connection.Query<CustomersOrderDTO>(Queries.GetAllOrdersByCustomerId,
                    new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
            return customersOrderDTOs;
        }


        public List<GetOrderModelDTO> GetOrderModel()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<GetOrderModelDTO>(Queries.GetOrderModel,
                     commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<GetOrderModelDTO> GetAllOrdersByStatusId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<GetOrderModelDTO>(Queries.GetAllOrdersByStatusId, new { id },
                     commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<CheckByOrderIdDTO> GetCheckByOrderId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CheckByOrderIdDTO>(Queries.GetCheckByOrderId, new { id },
                     commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}

