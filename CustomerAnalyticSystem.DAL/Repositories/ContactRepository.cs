using CustomerAnalyticSystem.DAL.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CustomerAnalyticSystem.DAL
{
    public class ContactRepository
    {
        public List<ContactDTO> GetAllContact()
        {
            List<ContactDTO> contactDTOs = new List<ContactDTO>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                contactDTOs = connection.Query<ContactDTO>(Queries.GetAllContact, commandType: CommandType.StoredProcedure).ToList();
            }
            return contactDTOs;
        }

        public ContactDTO GetContactById(int id)
        {
            ContactDTO contactDTO;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                contactDTO = connection.QuerySingle<ContactDTO>(Queries.GetContactById, new { id },
                commandType: CommandType.StoredProcedure);
            }
            return contactDTO;

        }

        public void AddContact(int CustomerId, int ContactTypeId, string Value)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.AddContact
                    , new { CustomerId, ContactTypeId, Value }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.Query(Queries.DeleteContact, new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateContact(int id, int CustomerId, int ContactTypeId, string Value)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<ContactDTO>(Queries.UpdateContact, new { id, CustomerId, ContactTypeId, Value },
                commandType: CommandType.StoredProcedure);
            }
        }

        public List<ContactTypeDTO> GetAllContactType()
        {
            List<ContactTypeDTO> contactDTOs = new List<ContactTypeDTO>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                contactDTOs = connection.Query<ContactTypeDTO>(Queries.GetAllContactType, commandType: CommandType.StoredProcedure).ToList();
            }
            return contactDTOs;
        }

        public ContactTypeDTO GetContactTypeById(int id)
        {
            ContactTypeDTO contactTypeDTO;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                contactTypeDTO = connection.QuerySingle<ContactTypeDTO>(Queries.GetContactTypeById, new { id }, commandType: CommandType.StoredProcedure);
            }
            return contactTypeDTO;
        }

        public void AddContactType(string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<ContactTypeDTO>(Queries.AddContactType
                    , new { Name }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteContactType(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<ContactTypeDTO>(Queries.DeleteContactType, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateContactType(int id, string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                connection.QuerySingle<ContactTypeDTO>(Queries.UpdateContactType, new { id, Name }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ContactWithContactTypeNameDTO> GetAllContactWithContactTypeByCustomerId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
            {
                return connection.Query<ContactWithContactTypeNameDTO>(
                    Queries.GetAllContactWithContactTypeByCustomerId
                    , new { id }
                    , commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}