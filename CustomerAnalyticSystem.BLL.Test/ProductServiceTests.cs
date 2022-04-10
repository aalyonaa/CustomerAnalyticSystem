using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using CustomerAnalyticSystem.BLL.Test.TestCaseSource.ProductTestCaseSource;
using CustomerAnalyticSystem.BLL.Test.TestCaseSourse;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test
{
    public class ProductServiceTests
    {

        #region tag

        [TestCaseSource(typeof(GetAllTagsTestCaseSource))]
        public void GetAllTagsTest(List<TagModel> expected, List<TagDTO> tagDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllTags()).Returns(tagDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<TagModel> actual = productTagGroupRepository.GetAllTags();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region group

        [TestCaseSource(typeof(GetAllGroupsTestCaseSource))]
        public void GetAllGroupTest(List<GroupBaseModel> expected, List<GroupBaseDTO> groupDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllGroup()).Returns(groupDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<GroupBaseModel> actual = productTagGroupRepository.GetAllGroups();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region product

        [TestCaseSource(typeof(GetAllProductsTestCaseSource))]
        public void GetAllProductsTest(List<ProductBaseModel> expected, List<ProductsWithGroupsDTO> productDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllProductsWithGroups()).Returns(productDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<ProductBaseModel> actual = productTagGroupRepository.GetAllProducts();

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region GetAllProductsByGroupId

        [TestCaseSource(typeof(GetAllProductsByGroupIdTestCaseSource))]
        public void GetAllProductsByGroupIdTest(int id, List<ProductBaseModel> expected, List<ProductsWithGroupsDTO> productDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllProductsByGroupId(id)).Returns(productDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<ProductBaseModel> actual = productTagGroupRepository.GetAllProductsByGroupId(id);

            //    CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region  GetAllTagsByProductId

        [TestCaseSource(typeof(GetAllTagsByProductIdTestCaseSource))]
        public void GetAllTagsByProductIdTest(int id, List<TagModel> expected, List<TagDTO> tagDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllTagsByProductId(id)).Returns(tagDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<TagModel> actual = productTagGroupRepository.GetAllTagsByProductId(id);

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region GetAllProductsByTag

        [TestCaseSource(typeof(GetAllProductsByTagTestCaseSource))]
        public void GetAllProductsByTagTest(int id, List<ProductBaseModel> expected, List<ProductsWithGroupsDTO> productDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllProductsByTag(id)).Returns(productDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<ProductBaseModel> actual = productTagGroupRepository.GetAllProductsByTagId(id);

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region GetAllProductsWithGroups

        [TestCaseSource(typeof(GetAllProductsWithGroupsTestCaseSource))]
        public void GetAllProductsWithGroupsTest(List<ProductBaseModel> expected, List<ProductsWithGroupsDTO> productDTO)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup((obj) => obj.GetAllProductsWithGroups()).Returns(productDTO);
            ProductService productTagGroupRepository = new ProductService(mock.Object);

            List<ProductBaseModel> actual = productTagGroupRepository.GetAllProducts();

            CollectionAssert.AreEqual(expected, actual);
        }


        #endregion
    }
}