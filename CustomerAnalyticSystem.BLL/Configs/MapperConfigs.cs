using AutoMapper;
using CustomerAnalyticSystem.BLL.Analytics;
using CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences.ForProduct;

namespace CustomerAnalyticSystem.BLL.Configs
{
    public class MapperConfigs
    {

        public MapperConfiguration ConfFromCustomerModelToCustomerDTO { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<CustomerModel, CustomerDTO>();
            });
        public MapperConfiguration ConfFromCustomerInfoModelToCustomerInfoDTO { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<CustomerInfoModel, CustomerInfoDTO>();
                conf.CreateMap<ContactModel, ContactWithContactTypeNameDTO>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.ContactTypeName, act => act.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value));
                conf.CreateMap<CommentModel, CommentDTO>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Text));
            });


        public MapperConfiguration ConfFromCustomerInfoDTOToCustomerinfoModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<CustomerInfoDTO, CustomerInfoModel>();
                conf.CreateMap<ContactWithContactTypeNameDTO, ContactModel>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, act => act.MapFrom(src => src.ContactTypeName))
               .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value));
                conf.CreateMap<CommentDTO, CommentModel>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Text));
            });

        public MapperConfiguration ConfFromCommentDTOToCommentModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<CommentDTO, CommentModel>();
            });

        public MapperConfiguration ConfFromCustomerInfoDTOToCustomerModel { get; private set; } = new MapperConfiguration(
           conf =>
           {
               conf.CreateMap<CustomerInfoDTO, CustomerInfoModel>();
               conf.CreateMap<ContactWithContactTypeNameDTO, ContactModel>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, act => act.MapFrom(src => src.ContactTypeName))
               .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value));
               conf.CreateMap<CommentDTO, CommentModel>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Text));
           });

        public MapperConfiguration ConfContactWithContactTypeDTOToContactModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<ContactWithContactTypeNameDTO, ContactModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.ContactTypeName));
            });


        public MapperConfiguration ConfFromContactTypeDTOToContactTypeModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<ContactTypeDTO, ContactTypeModel>();
            });

        public MapperConfiguration ConfFromCustomerTypeDTOToCustomerTypeModel { get; private set; } = new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<CustomerTypeDTO, CustomerTypeModel>();
                });

        public MapperConfiguration ConfFromCustomerDTOToCustomerModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<CustomerDTO, CustomerModel>();
            });

        public MapperConfiguration configOrderInfo { get; private set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AllOrderInfoByOrderId, OrderInfoByOrderIdModel>();
            cfg.CreateMap<CheckDTO, CheckBaseModel>().
            ForMember(dest => dest.Mark, act => act.MapFrom(src => src.Mark)).
            ForMember(dest => dest.Amount, act => act.MapFrom(src => src.Amount)).ForMember(dest => dest.ProductId, act => act.MapFrom(src => src.ProductId));
        });

        public MapperConfiguration ConfigAllGroupsWithProducts { get; private set; } = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<GroupsWithProductsDTO, GroupsWithProductsModel>();
                  cfg.CreateMap<ProductBaseDTO, ProductBaseModel>();
                  //cfg.CreateMap<List<OrderBaseModel>, List<OrderDTO>>();
                  cfg.CreateMap<OrderBaseModel, OrderDTO>();
                  cfg.CreateMap<OrderDTO, OrderBaseModel>();
              }
            );

        public MapperConfiguration ConfigBaseTag { get; private set; } = new MapperConfiguration(cfg =>
       {
           cfg.CreateMap<TagDTO, TagModel>();
       });

        public MapperConfiguration ConfigBaseProduct { get; private set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductsWithGroupsDTO, ProductBaseModel>();
        });

        public MapperConfiguration ConfigBaseGroup { get; private set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<GroupBaseDTO, GroupBaseModel>();
        });


        //public MapperConfiguration ConfigForBaseOrderModel = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<List<OrderBaseModel>, List<OrderDTO>>();
        //    cfg.CreateMap<OrderBaseModel, OrderDTO>().ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date)).ForMember(dest => dest.Cost, act => act.MapFrom(src => src.Cost))
        //    .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CustomerId)).ForMember(dest => dest.StatusId, act => act.MapFrom(src => src.StatusId));
        //});
        public MapperConfiguration ConfigCustomerPreferencesAndGrades = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<AllPreferencesAndGradeInfoByCustomerIdDTO, PreferencesByCustomerIdModel>()
            .ForMember(dest => dest.CustomerGrades, act => act.MapFrom(src => src.Grades));

            cfg.CreateMap<GroupForPrefDTO, GroupPrefModel>();
            cfg.CreateMap<TagForPrefDTO, TagPrefModel>();
            cfg.CreateMap<ProductForPrefDTO, ProductPrefModel>();
            cfg.CreateMap<GradeInfoByCustomerIdDTO, GradePrefModel>().ForMember(dest => dest.Id, act => act.MapFrom(src => src.ProductId));
            cfg.CreateMap<GradeInfoByCustomerIdForTagsDTO, CustomerTagGradesModel>();
        }
        );
        public MapperConfiguration ConfigStack = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<StackDTO, StackModel>();
            cfg.CreateMap<ProductBaseDTO, ProductBaseModel>();
            cfg.CreateMap<TagDTO, TagModel>();
            cfg.CreateMap<GroupBaseDTO, GroupBaseModel>();
            cfg.CreateMap<Product_TagDTO, ProductTagBaseModel>();
            cfg.CreateMap<OrderDTO, OrderBaseModel>();
            cfg.CreateMap<CheckDTO, CheckBaseModel>();
            cfg.CreateMap<GradeDTO, GradeBaseModel>();
        });



        public MapperConfiguration ConfFromOrderDTOToOrderBaseModel { get; private set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<GetOrderModelDTO, OrderBaseModel>();
            });

        public MapperConfiguration ConfigStatus { get; private set; } = new MapperConfiguration(conf =>
         {
             conf.CreateMap<StatusDTO, StatusModel>();
         });

        public MapperConfiguration ConfigCheckByOrderIdDTOToCheckByOrderIdModel { get; set; } = new MapperConfiguration(conf =>
        {
            conf.CreateMap<CheckByOrderIdDTO, CheckByOrderIdModel>();
        });


        public MapperConfiguration ConfigBasePreferences { get; private set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PreferencesDTO, PreferencesBaseModel>();
        });
    }
}
//Mapper.CreateMap<BaseModel, DataDestination>().IncludeAllDerived()
//Mapper.CreateMap<Car, DataDestination>();
//Mapper.CreateMap<Camper, DataDestination>();