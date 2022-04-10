using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.OrderTestCaseSource
{
    public class GetAllOrdersByStatusIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            int id = 8;
            List<OrderBaseModel> expected = new List<OrderBaseModel>() { new OrderBaseModel()
            { Id = 1, Date = "fjffjf", CustomerId = 500, FirstName = "qwe", LastName = "rty", Status = "qqq", Cost = 1212}
            , new OrderBaseModel()
            { Id = 1, Date = "asdfg", CustomerId = 5, FirstName = "qwtte", LastName = "rty", Status = "qqq!", Cost = 45678} };

            List<GetOrderModelDTO> checkDTO = new List<GetOrderModelDTO>() { new GetOrderModelDTO()
            { Id = 1, Date = "fjffjf", CustomerId = 500, FirstName = "qwe", LastName = "rty", Status = "qqq", Cost = 1212}
            , new GetOrderModelDTO()
            { Id = 1, Date = "asdfg", CustomerId = 5, FirstName = "qwtte", LastName = "rty", Status = "qqq!", Cost = 45678} };

            yield return new object[] { id, expected, checkDTO };

            int id2 = 8;
            List<OrderBaseModel> expected2 = new List<OrderBaseModel>() { };

            List<GetOrderModelDTO> checkDTO2 = new List<GetOrderModelDTO>() { };

            yield return new object[] { id2, expected2, checkDTO2 };


        }
    }
}


