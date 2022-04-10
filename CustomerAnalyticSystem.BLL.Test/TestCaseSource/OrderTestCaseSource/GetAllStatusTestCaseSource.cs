using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.OrderTestCaseSource
{
    public class GetAllStatusTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<StatusModel> expected = new List<StatusModel>() { new StatusModel() { Id = 1, Name = "fjffjf" }, new StatusModel() { Id = 3, Name = "qweqwe" } };
            List<StatusDTO> statusDTO = new() { new StatusDTO() { Id = 1, Name = "fjffjf" }, new StatusDTO() { Id = 3, Name = "qweqwe" } };
            yield return new object[] { expected, statusDTO };

            List<StatusModel> expected2 = new List<StatusModel>() { new StatusModel() { Id = 5, Name = "fjffjf" } };
            List<StatusDTO> statusDTO2 = new List<StatusDTO>() { new StatusDTO() { Id = 5, Name = "fjffjf" } };
            yield return new object[] { expected2, statusDTO2 };

            List<StatusModel> expected3 = new List<StatusModel>() { new StatusModel() { } };
            List<StatusDTO> statusDTO3 = new List<StatusDTO>() { new StatusDTO() { } };
            yield return new object[] { expected3, statusDTO3 };
        }


    }
}
