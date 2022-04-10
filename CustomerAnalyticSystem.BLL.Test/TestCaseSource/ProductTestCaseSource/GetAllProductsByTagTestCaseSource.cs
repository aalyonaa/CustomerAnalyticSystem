using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.ProductTestCaseSource
{
    public class GetAllProductsByTagTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;
            List<ProductBaseModel> expected = new List<ProductBaseModel>()
            { new ProductBaseModel() { Id = 1, Name = "fjffjf", Description = "qwerty", GroupName = "ytrewq", GroupId = 6}
            , new ProductBaseModel() { Id = 3, Name = "qweqwe", Description = "qwertyAA", GroupName = "ytrewqAA", GroupId = 3 } };

            List<ProductsWithGroupsDTO> productsWithGroupsDTO = new List<ProductsWithGroupsDTO>()
            { new ProductsWithGroupsDTO() { Id = 1, Name = "fjffjf", Description = "qwerty", GroupName = "ytrewq", GroupId = 6}
            , new ProductsWithGroupsDTO() { Id = 3, Name = "qweqwe", Description = "qwertyAA", GroupName = "ytrewqAA", GroupId = 3 } };

            yield return new object[] { id, expected, productsWithGroupsDTO };

            int id2 = 3;
            List<ProductBaseModel> expected2 = new List<ProductBaseModel>()
            { new ProductBaseModel() { Id = 1, Name = "ale", Description = "rty", GroupName = "ytrewq", GroupId = 7}
            , new ProductBaseModel() { Id = 3, Name = "qwe", Description = "qwertAA", GroupName = "ppp", GroupId = 2 } };

            List<ProductsWithGroupsDTO> productsWithGroupsDTO2 = new List<ProductsWithGroupsDTO>()
            { new ProductsWithGroupsDTO() { Id = 1, Name = "ale", Description = "rty", GroupName = "ytrewq", GroupId = 7}
            , new ProductsWithGroupsDTO() { Id = 3, Name = "qwe", Description = "qwertAA", GroupName = "ppp", GroupId = 2 } };

            yield return new object[] { id2, expected2, productsWithGroupsDTO2 };

            int id3 = 8;
            List<ProductBaseModel> expected3 = new List<ProductBaseModel>() { new ProductBaseModel() { } };
            List<ProductsWithGroupsDTO> ProductsWithGroupsDTO3 = new List<ProductsWithGroupsDTO>()
            { new ProductsWithGroupsDTO() { } };

            yield return new object[] { id3, expected3, ProductsWithGroupsDTO3 };
        }
    }
}