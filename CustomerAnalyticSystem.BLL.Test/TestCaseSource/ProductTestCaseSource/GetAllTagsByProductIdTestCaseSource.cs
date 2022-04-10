using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.ProductTestCaseSource
{
    public class GetAllTagsByProductIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;
            List<TagModel> expected = new List<TagModel>() { new TagModel() { Id = 1, Name = "fjffjf" }, new TagModel() { Id = 3, Name = "qweqwe" } };
            List<TagDTO> tagDTO = new List<TagDTO>() { new TagDTO() { Id = 1, Name = "fjffjf" }, new TagDTO() { Id = 3, Name = "qweqwe" } };
            yield return new object[] { id, expected, tagDTO };

            int id2 = 3;
            List<TagModel> expected2 = new List<TagModel>() { new TagModel() { Id = 5, Name = "fjffjf" } };
            List<TagDTO> tagDTO2 = new List<TagDTO>() { new TagDTO() { Id = 5, Name = "fjffjf" } };
            yield return new object[] { id2, expected2, tagDTO2 };

            int id3 = 6;
            List<TagModel> expected3 = new List<TagModel>() { new TagModel() { } };
            List<TagDTO> tagDTO3 = new List<TagDTO>() { new TagDTO() { } };
            yield return new object[] { id3, expected3, tagDTO3 };
        }


    }
}