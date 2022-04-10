using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.OrderTestCaseSource
{
    public class GetCheckByOrderIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 8;
            List<CheckByOrderIdModel> expected = new List<CheckByOrderIdModel>()
            { new CheckByOrderIdModel() { ProductId = 1, ProductName = "fjffjf", Amount = 500, Mark = 6}
            , new CheckByOrderIdModel() { ProductId = 3, ProductName = "qweqwe", Amount = 1000, Mark = 2 } };

            List<CheckByOrderIdDTO> checkDTO = new List<CheckByOrderIdDTO>()
            { new CheckByOrderIdDTO() { ProductId = 1, ProductName = "fjffjf", Amount = 500, Mark = 6}
            , new CheckByOrderIdDTO() { ProductId = 3, ProductName = "qweqwe", Amount = 1000, Mark = 2 } };

            yield return new object[] { id, expected, checkDTO };

            int id2 = 1;
            List<CheckByOrderIdModel> expected2 = new List<CheckByOrderIdModel>()
            { new CheckByOrderIdModel() { ProductId = 1, ProductName = "qwerty", Amount = 5070, Mark = 0}
            , new CheckByOrderIdModel() { ProductId = 3, ProductName = "qweqwe", Amount = 0, Mark = 2 } };

            List<CheckByOrderIdDTO> checkDTO2 = new List<CheckByOrderIdDTO>()
            { new CheckByOrderIdDTO() { ProductId = 1, ProductName = "qwerty", Amount = 5070, Mark = 0}
            , new CheckByOrderIdDTO() { ProductId = 3, ProductName = "qweqwe", Amount = 0, Mark = 2 } };

            yield return new object[] { id2, expected2, checkDTO2 };

            int id3 = 0;
            List<CheckByOrderIdModel> expected3 = new List<CheckByOrderIdModel>() { };

            List<CheckByOrderIdDTO> checkDTO3 = new List<CheckByOrderIdDTO>() { };

            yield return new object[] { id3, expected3, checkDTO3 };


        }
    }
}

