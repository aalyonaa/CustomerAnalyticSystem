using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSourse
{
    public class GetAllTagsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<TagModel> expected = new List<TagModel>() { new TagModel() { Id = 1, Name = "fjffjf" }, new TagModel() { Id = 3, Name = "qweqwe" } };
            List<TagDTO> tagDTO = new List<TagDTO>() { new TagDTO() { Id = 1, Name = "fjffjf" }, new TagDTO() { Id = 3, Name = "qweqwe" } };
            yield return new object[] { expected, tagDTO };

            List<TagModel> expected2 = new List<TagModel>() { new TagModel() { Id = 5, Name = "fjffjf" } };
            List<TagDTO> tagDTO2 = new List<TagDTO>() { new TagDTO() { Id = 5, Name = "fjffjf" } };
            yield return new object[] { expected2, tagDTO2 };

            List<TagModel> expected3 = new List<TagModel>() { new TagModel() { } };
            List<TagDTO> tagDTO3 = new List<TagDTO>() { new TagDTO() { } };
            yield return new object[] { expected3, tagDTO3 };
        }


    }
}
