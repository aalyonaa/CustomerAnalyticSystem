using AutoMapper;
using CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel;
using CustomerAnalyticSystem.BLL.Configs;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences.ForProduct;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL
{
    public class BestMapper
    {

        public CustomerDTO MapFromCustomerModelToCustomerDTO(CustomerModel model)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromCustomerModelToCustomerDTO)
                .Map<CustomerModel, CustomerDTO>(model);
        }
        public List<CommentModel> MapFromCommentDTOToCommentModel(List<CommentDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromCommentDTOToCommentModel)
                .Map<List<CommentDTO>, List<CommentModel>>(dto);
        }

        public OrderInfoByOrderIdModel MapOrderInfoByOrderId(AllOrderInfoByOrderId dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.configOrderInfo).Map<AllOrderInfoByOrderId, OrderInfoByOrderIdModel>(dto);
        }

        public List<CustomerTypeModel> MapCustomerTypeDTOToCustomerTypeModel(List<CustomerTypeDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromCustomerTypeDTOToCustomerTypeModel).Map<List<CustomerTypeDTO>, List<CustomerTypeModel>>(dto);
        }

        public List<GroupsWithProductsModel> MapGroupsWithProducts(List<GroupsWithProductsDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigAllGroupsWithProducts).Map<List<GroupsWithProductsDTO>, List<GroupsWithProductsModel>>(dto);
        }
        public CustomerInfoModel MapCustomerInfoDTOToCustomerModel(CustomerInfoDTO DTO)
        {
            var mapConfig = new MapperConfigs();
            return new Mapper(mapConfig.ConfFromCustomerInfoDTOToCustomerModel).Map<CustomerInfoDTO, CustomerInfoModel>(DTO);
        }

        public List<CustomerInfoModel> MapListCustomerDTOToListCustomerModel(List<CustomerInfoDTO> list)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromCustomerInfoDTOToCustomerinfoModel).Map<List<CustomerInfoDTO>, List<CustomerInfoModel>>(list);
        }
        public List<OrderBaseModel> MapBaseOrder(List<GetOrderModelDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromOrderDTOToOrderBaseModel).Map<List<GetOrderModelDTO>, List<OrderBaseModel>>(dto);
        }

        public List<TagModel> MapFromTagDTOToTagModel(List<TagDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigBaseTag).Map<List<TagDTO>, List<TagModel>>(dto);
        }

        public List<ProductBaseModel> MapFromProductBaseDTOToProductBaseModel(List<ProductsWithGroupsDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigBaseProduct).Map<List<ProductsWithGroupsDTO>, List<ProductBaseModel>>(dto);
        }

        public List<ContactTypeModel> MapFromContactTypeDTOToContactTypeModel(List<ContactTypeDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfFromContactTypeDTOToContactTypeModel)
                .Map<List<ContactTypeDTO>, List<ContactTypeModel>>(dto);
        }

        public List<ContactModel> MapFromContactWithContactTypeNameDTOToContactModel(List<ContactWithContactTypeNameDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfContactWithContactTypeDTOToContactModel)
                .Map<List<ContactWithContactTypeNameDTO>, List<ContactModel>>(dto);
        }

        public PreferencesByCustomerIdModel MapFromPreferences(AllPreferencesAndGradeInfoByCustomerIdDTO dto)
        {
            var config = new MapperConfigs();
            PreferencesByCustomerIdModel result = new Mapper(config.ConfigCustomerPreferencesAndGrades)
                .Map<AllPreferencesAndGradeInfoByCustomerIdDTO, PreferencesByCustomerIdModel>(dto);
            return result;
        }
        public StackModel GetAllInfoForProductAnalise(StackDTO dto)
        {
            var config = new MapperConfigs();
            StackModel result = new Mapper(config.ConfigStack).Map<StackDTO, StackModel>(dto);
            return result;
        }


        public List<GroupBaseModel> MapFromGroupBaseDTOToGroupBaseModel(List<GroupBaseDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigBaseGroup).Map<List<GroupBaseDTO>, List<GroupBaseModel>>(dto);
        }

        public List<OrderBaseModel> MapFromOrderDTOToOrderBaseModel(List<GetOrderModelDTO> DTO)
        {
            var mapConfig = new MapperConfigs();
            return new Mapper(mapConfig.ConfFromOrderDTOToOrderBaseModel).Map<List<GetOrderModelDTO>
               , List<OrderBaseModel>>(DTO);
        }
        public List<PreferencesBaseModel> MapFromPreferencesDTOToPreferenceBaseModel(List<PreferencesDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigBasePreferences).Map<List<PreferencesDTO>, List<PreferencesBaseModel>>(dto);
        }

        public List<StatusModel> MapFromStatus(List<StatusDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigStatus).Map<List<StatusDTO>, List<StatusModel>>(dto);
        }

        public List<CheckByOrderIdModel> MapCheckByOrderId(List<CheckByOrderIdDTO> dto)
        {
            var config = new MapperConfigs();
            return new Mapper(config.ConfigCheckByOrderIdDTOToCheckByOrderIdModel).Map<List<CheckByOrderIdDTO>
               , List<CheckByOrderIdModel>>(dto);
        }
    }

}