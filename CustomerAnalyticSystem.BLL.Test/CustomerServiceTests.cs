using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Test.TestCaseSource.CustomerTestCaseSource;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test
{
    public class CustomerServiceTests
    {
        [TestCaseSource(typeof(GetAllCustomerTypeTestCaseSource))]
        public void GetAllCustomerTypeTest(List<CustomerTypeModel> expected, List<CustomerTypeDTO> customerTypeDTO)
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup((obj) => obj.GetAllCustomerType()).Returns(customerTypeDTO);
            CustomerService customerService = new CustomerService(mock.Object);

            List<CustomerTypeModel> actual = customerService.GetAllCustomerTypeModel();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllCustomerInfoDTOTestCaseSource))]
        public void GetAllCustomerInfoDTOTest(
            List<CustomerInfoDTO> customerInfoDTO
            , List<CustomerInfoModel> expected)
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup((obj) => obj.GetAllCustomerInfoDTO()).Returns(customerInfoDTO);
            CustomerService customerService = new CustomerService(mock.Object);

            List<CustomerInfoModel> actual = customerService.GetAllCustomerInfoModels();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
