using AutoMapper;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using CustomerAnalyticSystem.DAL.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{

    //Есть средняя оценка продукта для каждого кастомера
    //есть преференцы групп тегов продуктов для каждого кастомера
    //НЕТ популярности групп тегов продуктов
    public class AllCustomersPreferences
    {

        private List<CustomerInfoModel> BaseCustomers { get; set; }
        public List<PreferencesBaseModel> CustomersPreferences { get; set; }//Ключ - айди кастомера вся инфа тянется оттуда



        public Dictionary<int, ConcreteCustomer> Customers { get; set; }
        public GeneralStatistics InfoToAnalise { get; set; }

        private Dictionary<(int, int), List<int>> CustomerIdProductIdMark { get; set; }
        public MapperConfiguration configuration { get; set; } = new(cfg =>
          {
              cfg.CreateMap<CustomerInfoModel, ConcreteCustomer>();
              cfg.CreateMap<CustomerDTO, CustomerInfoModel>();
          });
        public AllCustomersPreferences(GeneralStatistics stat)
        {
            PreferencesService preferences = new();
            InfoToAnalise = stat;
            Customers = new();
            CustomersPreferences = preferences.GetBasePreferencesModel();


            List<CustomerInfoModel> Custs = new();
            CustomerService serve = new();
            List<CustomerDTO> we = serve.GetAllCustomers();
            BaseCustomers = new Mapper(configuration).Map<List<CustomerDTO>, List<CustomerInfoModel>>(we);
            MakeStatisticksForCustomers();

        }
        private void MakeStatisticksForCustomers()
        {
            FillBaseCustomerInfo();
            AvgMarkForEveryProduct();
            FindAllBestsellers();
            foreach (var c in Customers)
            {
                c.Value.AvgMarkForEveryProduct();
                c.Value.GetAllCurrentCustomerOrders();
            }
        }

        private void FillCustomerPreferences()
        {
            foreach (var pref in CustomersPreferences)//билдим префы для кастомеров
            {
                int value = 0;
                if (pref.IsInterested == true)
                {
                    value = 1;
                }
                else
                    value = -1;
                if (Customers.ContainsKey(pref.CustomerId))
                {
                    if (pref.ProductId != 0)
                    {
                        if (Customers[pref.CustomerId].PreferenceByProductId.ContainsKey(pref.ProductId) == false)
                        {
                            Customers[pref.CustomerId].PreferenceByProductId.Add(pref.ProductId, value);
                        }
                        else
                        {
                            Customers[pref.CustomerId].PreferenceByProductId[pref.ProductId] = value;
                        }
                    }
                    else if (pref.GroupId != 0)
                    {
                        if (Customers[pref.CustomerId].PreferenceByProductId.ContainsKey(pref.GroupId) == false)
                        {
                            Customers[pref.CustomerId].PreferenceByProductId.Add(pref.GroupId, value);
                        }
                        else
                        {
                            Customers[pref.CustomerId].PreferenceByProductId[pref.GroupId] = value;
                        }
                    }
                    else if (pref.TagId != 0)
                    {
                        if (Customers[pref.CustomerId].PreferenceByProductId.ContainsKey(pref.ProductId) == false)
                        {
                            Customers[pref.CustomerId].PreferenceByProductId.Add(pref.TagId, value);
                        }
                        else
                        {
                            Customers[pref.CustomerId].PreferenceByProductId[pref.TagId] = value;
                        }
                    }
                }
            }
        }


        private void FillBaseCustomerInfo()//запускается первым делом чтобы не обосраться
        {
            foreach (var customer in BaseCustomers)
            {
                ConcreteCustomer cust = new Mapper(configuration).Map<CustomerInfoModel, ConcreteCustomer>(customer);
                cust.AllOneProductMarks = new();
                Customers.Add(cust.Id, cust);
                Customers[cust.Id].IncludeStatistics(InfoToAnalise);
                Customers[cust.Id].PreferenceByProductId = new();
                Customers[cust.Id].PreferenceByGroupId = new();
                Customers[cust.Id].PreferenceByTagId = new();
                Customers[cust.Id].AllocatePlaceesForGroupsAndTags();
            }
            FillCustomerPreferences();
        }

        // ТУДУ: 
        private void AvgMarkForEveryProduct()//есть средняя оценка для каждого продукта
        {
            foreach (var grade in InfoToAnalise.Info.Grades)
            {
                if (Customers.ContainsKey(grade.CustomerId))
                {
                    if (Customers[grade.CustomerId].AllOneProductMarks.ContainsKey(grade.ProductId) == false)
                    {
                        Customers[grade.CustomerId].AllOneProductMarks.Add(grade.ProductId, new());
                    }
                    Customers[grade.CustomerId].AllOneProductMarks[grade.ProductId].Add(grade.Value);

                }
            }
        }

        private void BoundGradeCustomer()
        {
            CustomerIdProductIdMark = new();
            foreach (var grade in InfoToAnalise.Info.Grades)
            {
                if (CustomerIdProductIdMark.ContainsKey((grade.CustomerId, grade.ProductId)) == false)
                {
                    CustomerIdProductIdMark.Add((grade.CustomerId, grade.ProductId), new());
                }
                CustomerIdProductIdMark[(grade.CustomerId, grade.ProductId)].Add(grade.Value);
            }
        }


        private void SortGrades()
        {
            foreach (var c in CustomerIdProductIdMark)
            {
                int i = c.Value[1];
                if (Customers.ContainsKey(c.Key.Item1))
                {
                    if (Customers[c.Key.Item1].AllOneProductMarks.ContainsKey(c.Key.Item2) == true)
                    {
                        Customers[c.Key.Item1].AllOneProductMarks[c.Key.Item2] = c.Value;
                    }
                    else
                    {
                        Customers[c.Key.Item1].AllOneProductMarks.Add(c.Key.Item2, c.Value);
                    }
                }

            }
        }
        private void FindAllBestsellers()//количество появления продукта в каждом заказе
        {
            //BoundCheckProduct();//уже готовый список в ИнфоТуАнализ
            BoundGradeCustomer();//связываем по составному ключу (ИД кастомера и ИД продукта) НУЖНО???
            SortGrades();//раскидывает оценки по сложному ключу в каждого кастомера ----------- НУЖНО???
            List<int> isContainTag;
            List<int> isContainGroup;


            foreach (var order in InfoToAnalise.Info.Orders)
            {
                if (Customers.ContainsKey(order.CustomerId))
                {
                    isContainGroup = InfoToAnalise.Groups.Keys.ToList();
                    isContainTag = InfoToAnalise.Tags.Keys.ToList();
                    foreach (var prod in InfoToAnalise.Products)
                    {
                        if (InfoToAnalise.IsContains(order.Id, prod.Key))
                        {
                            if (Customers[order.CustomerId].ProductPercent is null)
                            {
                                Customers[order.CustomerId].ProductPercent = new();
                            }
                            if (Customers[order.CustomerId].ProductPercent.ContainsKey(prod.Key) == false)
                            {
                                Customers[order.CustomerId].ProductPercent.Add(prod.Key, 0);
                                if (Customers[order.CustomerId].ProductsRecommends.ContainsKey(prod.Key) == false)
                                {
                                    Customers[order.CustomerId].ProductsRecommends.Add(prod.Key, new(prod.Key, prod.Value.Name));
                                }
                            }
                            Customers[order.CustomerId].ProductsRecommends[prod.Key].Percent++;
                            Customers[order.CustomerId].ProductPercent[prod.Key]++;
                            InfoToAnalise.ComparingTagAndProduct(isContainTag, prod.Key);
                            InfoToAnalise.ComparingGroupAndProduct(isContainGroup, prod.Key);
                        }
                    }
                    Customers[order.CustomerId].GetPopularityGroup(isContainGroup);//ТУДУ
                    Customers[order.CustomerId].GetPopularityTag(isContainTag);//ТУДУ
                }
            }
            //ConvertToPercents(ConvertToPercent.product);//внутри кастомера
            //ConvertToPercents(ConvertToPercent.group);//внутри кастомера
            //ConvertToPercents(ConvertToPercent.tag);//внутри кастомера
        }
    }
}