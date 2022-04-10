using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CustomerAnalyticSystem.DAL
{
    public class CustomerTypeCustomerCommentRepository : ICustomerRepository
    {
        public List<CustomerTypeDTO> GetAllCustomerType()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CustomerTypeDTO>(Queries.GetAllCustomerType
                    , commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CustomerTypeDTO GetCustomerTypeById(int id)
        {
            CustomerTypeDTO type = new CustomerTypeDTO();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                type = connection.QuerySingle<CustomerTypeDTO>(Queries.GetCustomerTypeById
                    , new { id }
                    , commandType: CommandType.StoredProcedure);
            }
            return type;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CustomerDTO>(Queries.GetAllCustomers
                    , commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CustomerDTO GetCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                try
                {
                    return connection.QuerySingle<CustomerDTO>(Queries.GetCustomerById
                        , new { id }
                        , commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Нет клиента с таким Id", ex);
                }
            };
        }

        public void UpdateCustomerTypeById(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.UpdateCustomerTypeById
                    , new { id, name }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCustomer(CustomerDTO customer)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.AddCustomer
                    , new { customer.LastName, customer.FirstName, customer.TypeId }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCustomerById(int id, string firstName, string lastName, int typeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.UpdateCustomerById
                    , new { id, firstName, lastName, typeId }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.DeleteCustomerById
                    , new { id }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCustomerTypeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.DeleteCustomerTypeById
                    , new { id }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCustomerType(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.AddCustomerType
                    , new { name }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public CustomerInfoDTO GetCustomerByIdWithCustomerType(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.QuerySingle<CustomerInfoDTO>(Queries.GetCustomerByIdWithCustomerType, new { id }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public List<CommentDTO> GetAllCommentByCustomerId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CommentDTO>(Queries.GetAllCommentByCustomerId, new { id }
                , commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ContactWithContactTypeNameDTO> GetAllContactByCustomerId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<ContactWithContactTypeNameDTO>(Queries.GetAllContactByCustomerId,
                    new { id }
                    , commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CustomerInfoDTO GetCustomerInfoService(int id)
        {
            CustomerInfoDTO customer = new();

            customer = GetCustomerByIdWithCustomerType(id);
            customer.Comments = GetAllCommentByCustomerId(id);
            customer.Contacts = GetAllContactByCustomerId(id);

            return customer;
        }

        public List<CustomerInfoDTO> GetAllCustomerInfoDTO()
        {
            Dictionary<int, CustomerInfoDTO> customersDict = new Dictionary<int, CustomerInfoDTO>();
            int curCustomerId = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<CustomerInfoDTO, ContactWithContactTypeNameDTO, CustomerInfoDTO>(
                    Queries.GetAllCustomerWithContactAndContactType
                    , (customerInfo, contact) =>
                     {
                         if (curCustomerId != customerInfo.Id)
                         {
                             customersDict.Add(customerInfo.Id, customerInfo);
                             curCustomerId = customerInfo.Id;
                             customersDict[curCustomerId].Contacts = new List<ContactWithContactTypeNameDTO>();
                             customersDict[curCustomerId].Comments = new List<CommentDTO>();
                         }

                         customersDict[curCustomerId].Contacts.Add(contact);
                         return customersDict[curCustomerId];
                     }
                    , splitOn: "Id"
                    , commandType: CommandType.StoredProcedure);
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query<CommentDTO, object, CommentDTO>(
                    Queries.GetAllSortedComments
                    , (comment, obj) =>
                     {
                         if (customersDict.Count > 0)
                         {
                             customersDict[comment.CustomerId].Comments.Add(comment);
                         }
                         return comment;
                     }
                     , splitOn: "TempId"
                    , commandType: CommandType.StoredProcedure);
            }

            return customersDict.Values.ToList();
        }

        public List<TagMarksDTO> GetAllMarksOfTagByCustomerId(int id)
        {
            List<TagMarksDTO> tagMarksDTOs = new List<TagMarksDTO>();
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                tagMarksDTOs = connection.Query<TagMarksDTO>(Queries.GetAllTagsWithMarksByCustomerId, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
            return tagMarksDTOs;
        }

        public List<CustomerPreferenceDTO> GetAllPreferencesByCustomerId(int id)
        {
            List<CustomerPreferenceDTO> customerPreferenceDTOs = new List<CustomerPreferenceDTO>();
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                customerPreferenceDTOs = connection.Query<CustomerPreferenceDTO>(Queries.GetAllPreferencesByCustomerId, new { id },
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return customerPreferenceDTOs;
        }

        public List<CommentDTO> GetAllComment()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<CommentDTO>(Queries.GetAllComment, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CommentDTO GetCommentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.QuerySingle<CommentDTO>(Queries.GetCommentById, new { id },
                commandType: CommandType.StoredProcedure);
            }

        }

        public void AddComment(int CustomerId, string Text)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.AddComment, new { CustomerId, Text },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteComment(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.DeleteComment, new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateComment(int id, int CustomerId, string Value)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<CommentDTO>(Queries.UpdateComment, new { id, CustomerId, Value },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}