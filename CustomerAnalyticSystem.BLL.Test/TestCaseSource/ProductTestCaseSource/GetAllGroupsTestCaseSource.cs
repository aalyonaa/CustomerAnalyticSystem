using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.ProductTestCaseSource
{
    public class GetAllGroupsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<GroupBaseModel> expected = new List<GroupBaseModel>() { new GroupBaseModel() { Id = 1, Name = "fjffjf" }, new GroupBaseModel() { Id = 3, Name = "qweqwe" } };
            List<GroupBaseDTO> GroupBaseDTO = new List<GroupBaseDTO>() { new GroupBaseDTO() { Id = 1, Name = "fjffjf" }, new GroupBaseDTO() { Id = 3, Name = "qweqwe" } };
            yield return new object[] { expected, GroupBaseDTO };

            List<GroupBaseModel> expected2 = new List<GroupBaseModel>() { new GroupBaseModel() { Id = 5, Name = "fjffjf" } };
            List<GroupBaseDTO> GroupBaseDTO2 = new List<GroupBaseDTO>() { new GroupBaseDTO() { Id = 5, Name = "fjffjf" } };
            yield return new object[] { expected2, GroupBaseDTO2 };

            List<GroupBaseModel> expected3 = new List<GroupBaseModel>() { new GroupBaseModel() { } };
            List<GroupBaseDTO> GroupBaseDTO3 = new List<GroupBaseDTO>() { new GroupBaseDTO() { } };
            yield return new object[] { expected3, GroupBaseDTO3 };
        }


    }
}
