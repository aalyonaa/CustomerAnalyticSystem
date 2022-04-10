using AutoMapper;
using CustomerAnalyticSystem.BLL.Models;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{
    public class AllProductsAnalytic
    {

        public Dictionary<int, ConcreteProduct> Products { get; set; }// ключ - айди продукта, три листа с группами тегами и продуктами

        public AllCustomersPreferences AllCustomers { get; set; }
        public StackModel Tables { get; set; }
        public GeneralStatistics MainAnalytics { get; set; }

        internal MapperConfiguration config { get; set; } = new(cfg =>
            {
                cfg.CreateMap<ProductBaseModel, ConcreteProduct>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.GroupName, act => act.MapFrom(src => src.GroupName));
                cfg.CreateMap<ItemToRecommend, ConcreteProduct>();


            }
        );
        public AllProductsAnalytic(AllCustomersPreferences cust)
        {
            AllCustomers = cust;
            MainAnalytics = cust.InfoToAnalise;
            Tables = cust.InfoToAnalise.Info;
            Products = new();
            MakeProductStatistics();
        }

        private void MakeProductStatistics()
        {
            GetListOfProducts();
            BoundCustomersAndProduct();
        }
        private void GetListOfProducts()//начало первый метод для вызова
        {
            foreach (var prod in MainAnalytics.Products)
            {
                var dictProd = new Mapper(config).Map<ItemToRecommend, ConcreteProduct>(prod.Value);
                Products.Add(prod.Value.Id, dictProd);
                Products[prod.Value.Id].Customers = new();
            }
        }

        private void BoundCustomersAndProduct()//второй метод
        {
            foreach (var cust in AllCustomers.Customers)
            {
                foreach (var pref in cust.Value.PreferenceByProductId)
                {
                    if (pref.Value == 1)
                    {
                        if (Products.ContainsKey(pref.Key))
                        {
                            Products[pref.Key].Customers.Add(cust.Value);
                        }
                    }
                }
            }
        }

    }
}
