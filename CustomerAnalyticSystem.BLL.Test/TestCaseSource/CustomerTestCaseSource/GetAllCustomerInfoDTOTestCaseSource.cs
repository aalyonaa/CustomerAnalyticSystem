using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;


namespace CustomerAnalyticSystem.BLL.Test.TestCaseSource.CustomerTestCaseSource
{
    public class GetAllCustomerInfoDTOTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<CustomerInfoModel> expected = new List<CustomerInfoModel>()
            {
                new CustomerInfoModel()
                { Id = 1, FirstName = "www", LastName = "qqq"
                , TypeId = 1, Name="zzz"
                , Contacts = new List<ContactModel>() {
                    new ContactModel() { Id = 1, Value = "123", Name = "qwe" }
                    ,new ContactModel() { Id = 2, Value = "234", Name = "rty" }}
                , Comments = new List<CommentModel>() {
                    new CommentModel(){Id = 1, Text = ".,mnb"}}

                }
                , new CustomerInfoModel()
                { Id = 11, FirstName = "eee", LastName = "rrr"
                , TypeId = 12, Name="ttt"
                , Contacts = new List<ContactModel>() {
                    new ContactModel() { Id = 13, Value = "321", Name = "ewq" }
                    ,new ContactModel() { Id = 2, Value = "432", Name = "ytr"}}
                , Comments = new List<CommentModel>() {
                    new CommentModel(){Id = 4, Text = "bnm,."}}
                }
            };

            List<CustomerInfoDTO> customerInfoDTO = new List<CustomerInfoDTO>() {
                new CustomerInfoDTO()
                { Id = 1, FirstName = "www", LastName = "qqq"
                , TypeId = 1, Name="zzz"
                , Contacts = new List<ContactWithContactTypeNameDTO>() {
                    new ContactWithContactTypeNameDTO() {  Id = 1, Value = "123", ContactTypeName = "qwe"  }
                    ,new ContactWithContactTypeNameDTO() { Id = 2, Value = "234", ContactTypeName = "rty" }}
                , Comments = new List<CommentDTO>() {
                    new CommentDTO(){Id = 1, Text = ".,mnb"}}
            }
                ,new CustomerInfoDTO()
                { Id = 11, FirstName = "eee", LastName = "rrr"
                , TypeId = 12, Name="ttt"
                , Contacts = new List<ContactWithContactTypeNameDTO>() {
                    new ContactWithContactTypeNameDTO() {  Id = 13, Value = "321", ContactTypeName = "ewq" }
                    ,new ContactWithContactTypeNameDTO() { Id = 2, Value = "432", ContactTypeName = "ytr" }}
                , Comments = new List<CommentDTO>() {
                    new CommentDTO(){Id = 4, Text = "bnm,."}}
            }
        };
            yield return new object[] { customerInfoDTO, expected };
        }
    }
}
