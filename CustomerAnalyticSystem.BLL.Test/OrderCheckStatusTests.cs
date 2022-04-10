using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using CustomerAnalyticSystem.BLL.Test.TestCaseSource.OrderTestCaseSource;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource
{
    public class OrderCheckStatusTests
    {
        #region status
        [TestCaseSource(typeof(GetAllStatusTestCaseSource))]
        public void GetAllStatusTest(List<StatusModel> expected, List<StatusDTO> statusDTO)
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            mock.Setup((obj) => obj.GetAllStatus()).Returns(statusDTO);
            OrderCheckStatusService orderService = new OrderCheckStatusService(mock.Object);

            List<StatusModel> actual = orderService.GetAllStatus();

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region GetAllOrdersByStatusId

        [TestCaseSource(typeof(GetAllOrdersByStatusIdTestCaseSource))]
        public void GetAllOrdersByStatusIdTest(int id, List<OrderBaseModel> expected, List<GetOrderModelDTO> orderDTO)
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            mock.Setup((obj) => obj.GetAllOrdersByStatusId(id)).Returns(orderDTO);
            OrderCheckStatusService orderService = new OrderCheckStatusService(mock.Object);

            List<OrderBaseModel> actual = orderService.GetAllOrdersByStatusId(id);

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region GetCheckByOrderId        

        [TestCaseSource(typeof(GetCheckByOrderIdTestCaseSource))]
        public void GetCheckByOrderIdTest(int id, List<CheckByOrderIdModel> expected, List<CheckByOrderIdDTO> orderDTO)
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            mock.Setup((obj) => obj.GetCheckByOrderId(id)).Returns(orderDTO);
            OrderCheckStatusService orderService = new OrderCheckStatusService(mock.Object);

            List<CheckByOrderIdModel> actual = orderService.GetCheckByOrderId(id);

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
