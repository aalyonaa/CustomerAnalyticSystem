using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL
{
    public class CustomerService
    {

        protected ICustomerRepository _rep = new CustomerTypeCustomerCommentRepository();

        public CustomerService(ICustomerRepository rep = null)
        {
            if (rep is not null)
            {
                _rep = rep;
            }
        }

        public List<CustomerTypeModel> GetAllCustomerTypeModel()
        {
            List<CustomerTypeDTO> DTOs = _rep.GetAllCustomerType();
            BestMapper map = new BestMapper();
            return map.MapCustomerTypeDTOToCustomerTypeModel(DTOs);
        }

        public void AddCustomer(CustomerModel model)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            BestMapper map = new BestMapper();
            CustomerDTO customer = map.MapFromCustomerModelToCustomerDTO(model);
            rep.AddCustomer(customer);
        }

        public CustomerInfoModel GetCustomerModel(int id)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            var DTO = rep.GetCustomerInfoService(id);
            var map = new BestMapper();
            CustomerInfoModel result = map.MapCustomerInfoDTOToCustomerModel(DTO);

            return result;
        }

        public List<CustomerInfoModel> GetAllCustomerInfoModels()
        {
            List<CustomerInfoDTO> customers = _rep.GetAllCustomerInfoDTO();
            var map = new BestMapper();

            return map.MapListCustomerDTOToListCustomerModel(customers);
        }

        public void UpdateCustomer(CustomerInfoModel customer)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            rep.UpdateCustomerById(customer.Id, customer.FirstName, customer.LastName, customer.TypeId);
        }

        public void DeleteCustomerById(int id)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            rep.DeleteCustomerById(id);
        }

        public void AddCommentByCustomerId(int customerId, CommentModel model)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            rep.AddComment(customerId, model.Text);
        }

        public void DeleteCommentById(int id)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            rep.DeleteComment(id);
        }

        public List<CommentModel> GetAllCommentByCustomerId(int id)
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            List<CommentDTO> coments = rep.GetAllCommentByCustomerId(id);
            var map = new BestMapper();
            return map.MapFromCommentDTOToCommentModel(coments);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
            return rep.GetAllCustomers();
        }

        //public List<CustomerTypeModel> GetAllCustomerTypeModel()
        //{
        //    List<CustomerTypeModel> customerTypes = new List<CustomerTypeModel>();

        //    CustomerTypeCustomerCommentRepository rep = new CustomerTypeCustomerCommentRepository();
        //    List<CustomerTypeDTO> DTOs = rep.GetAllCustomerType();
        //    MrMappi map = new MrMappi();
        //    customerTypes = map.MapCustomerTypeDTOToCustomerTypeModel(DTOs);

        //    return customerTypes;
        //}
    }
}
