using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.CustomerTestCaseSource
{
    public class GetAllCustomerTypeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<CustomerTypeModel> expected = new List<CustomerTypeModel>() { new CustomerTypeModel() { Id = 1, Name = "qqq" }, new CustomerTypeModel() { Id = 2, Name = "www" } };
            List<CustomerTypeDTO> CustomerTypeDTO = new List<CustomerTypeDTO>() { new CustomerTypeDTO() { Id = 1, Name = "qqq" }, new CustomerTypeDTO() { Id = 2, Name = "www" } };
            yield return new object[] { expected, CustomerTypeDTO };

            List<CustomerTypeModel> expected2 = new List<CustomerTypeModel>() { new CustomerTypeModel() { Id = 555, Name = "555" } };
            List<CustomerTypeDTO> CustomerTypeModelDTO2 = new List<CustomerTypeDTO>() { new CustomerTypeDTO() { Id = 555, Name = "555" } };
            yield return new object[] { expected2, CustomerTypeModelDTO2 };

            List<CustomerTypeModel> expected3 = new List<CustomerTypeModel>() { new CustomerTypeModel() { } };
            List<CustomerTypeDTO> CustomerTypeDTO3 = new List<CustomerTypeDTO>() { new CustomerTypeDTO() { } };
            yield return new object[] { expected3, CustomerTypeDTO3 };
        }
    }
}
