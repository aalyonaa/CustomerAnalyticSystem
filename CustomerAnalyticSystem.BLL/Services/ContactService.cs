using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Services
{
    public class ContactService
    {

        public List<ContactTypeModel> GetAllContactTypeModel()
        {
            ContactRepository rep = new ContactRepository();
            List<ContactTypeDTO> DTO = rep.GetAllContactType();
            BestMapper map = new BestMapper();
            return map.MapFromContactTypeDTOToContactTypeModel(DTO);
        }

        public void AddContact(ContactBaseModel contact)
        {
            ContactRepository rep = new ContactRepository();
            rep.AddContact(contact.CustomerId, contact.ContactTypeId, contact.Value);
        }

        public void UpdateContact(int id, int customerId, int contactTypeId, string value)
        {
            ContactRepository rep = new ContactRepository();
            rep.UpdateContact(id, customerId, contactTypeId, value);
        }

        public void DeleteContact(int id)
        {
            ContactRepository rep = new ContactRepository();
            rep.DeleteContact(id);
        }

        public void UpdateContactType(int id, string name)
        {
            ContactRepository rep = new ContactRepository();
            rep.UpdateContactType(id, name);
        }

        public void DeleteContactType(int id)
        {
            ContactRepository rep = new ContactRepository();
            rep.DeleteContactType(id);
        }

        public List<ContactModel> GetAllContactModelByCustomerId(int id)
        {
            ContactRepository rep = new ContactRepository();
            var DTOs = rep.GetAllContactWithContactTypeByCustomerId(id);
            BestMapper map = new BestMapper();
            return map.MapFromContactWithContactTypeNameDTOToContactModel(DTOs);
        }
    }
}
