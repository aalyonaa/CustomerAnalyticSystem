using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAnalyticSystem.BLL.Analytics
{
    public class PreferredProductsForOneCustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<GradePrefModel> TrueMarkForProduct { get; set; }
        public List<GradePrefModel> TrueMarkForTag { get; set; }
        public List<GroupPrefModel> GroupPreferences { get; set; }



        private PreferencesByCustomerIdModel Preferences { get; set; }

        // public List<TagPrefModel> Tags - ТЕГИПРЕФЫ
        // public List<CustomerTagGradesModel> TagGrades ТЕГИОЦЕНКИ

        enum ProductTag
        {
            Product = 1,
            Tag = 2
        }

        public PreferredProductsForOneCustomer(PreferencesByCustomerIdModel preferences)
        {
            CustomerId = preferences.Id;
            FirstName = preferences.FirstName;
            LastName = preferences.LastName;
            Preferences = preferences;
            GroupPreferences = preferences.Groups;
            CheckForTag();
            CheckProductMark();
        }

        public void CheckProductMark()
        {
            MapperConfiguration configProduct = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPrefModel, GradePrefModel>();

            });
            Dictionary<int, GradePrefModel> products = new();
            foreach (var c in Preferences.Products)
            {
                var temp = new Mapper(configProduct).Map<ProductPrefModel, GradePrefModel>(c);
                if (c.IsInterested == false)
                {
                    temp.Value = -1;
                }
                else
                    temp.Value = 11;
                products.Add(temp.Id, temp);
            }
            foreach (var c in Preferences.CustomerGrades)
            {
                if (products.ContainsKey(c.Id) == false)
                {
                    c.Value = GetWeightedAverageMark(Preferences.CustomerGrades, c.Id, ProductTag.Product);
                    products.Add(c.Id, c);
                }
            }
            TrueMarkForProduct = products.Values.ToList();
        }


        private int GetWeightedAverageMark(object allMarksList, int id, ProductTag productOrTag)
        {
            int i = 0;
            List<int> allGrades = new();
            if (productOrTag is ProductTag.Tag)
            {
                List<CustomerTagGradesModel> allMarks = (List<CustomerTagGradesModel>)allMarksList;
                while (i < allMarks.Count)
                {
                    if (allMarks[i].Id == id)
                    {
                        if (allMarks[i].Mark > 10)
                        {
                            allMarks[i].Mark = 10;
                        }
                        if (allMarks[i].Mark < 0)
                        {
                            allMarks[i].Mark = 0;
                        }
                        allGrades.Add(allMarks[i].Mark);
                    }
                    i++;
                }
            }
            else
            {
                List<GradePrefModel> allMarks = (List<GradePrefModel>)allMarksList;
                while (i < allMarks.Count)
                {
                    if (allMarks[i].Id == id)
                    {
                        if (allMarks[i].Value > 10)
                            allMarks[i].Value = 10;
                        if (allMarks[i].Value < 0)
                            allMarks[i].Value = 0;
                        allGrades.Add(allMarks[i].Value);
                    }
                    i++;
                }
            }
            if (allGrades.Count == 2)
                return (allGrades[0] + allGrades[1]) / 2;
            else if (allGrades.Count == 1)
                return allGrades[0];
            return allGrades[allGrades.Count / 2];
        }


        public MapperConfiguration configTagPrefModel = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TagPrefModel, GradePrefModel>();
        });
        public MapperConfiguration configCustomerTagGradesModel = new MapperConfiguration(cfg =>
            cfg.CreateMap<CustomerTagGradesModel, GradePrefModel>().ForMember(dest => dest.Value, act => act.MapFrom(src => src.Mark))
        );


        public void CheckForTag()
        {
            TrueMarkForTag = new();
            Dictionary<int, GradePrefModel> tages = new();
            foreach (var c in Preferences.Tags)
            {
                var temp = new Mapper(configTagPrefModel).Map<TagPrefModel, GradePrefModel>(c);
                if (c.IsInterested == true)
                    temp.Value = 11;
                else
                    temp.Value = -1;
                TrueMarkForTag.Add(temp);
                tages.Add(temp.Id, temp);
            }
            foreach (var c in Preferences.TagGrades)
            {
                if (tages.ContainsKey(c.Id) == false)
                {
                    c.Mark = GetWeightedAverageMark(Preferences.TagGrades, c.Id, ProductTag.Tag);
                }
                var temp = new Mapper(configCustomerTagGradesModel).Map<CustomerTagGradesModel, GradePrefModel>(c);
                if (tages.ContainsKey(temp.Id) == false)
                {
                    tages.Add(temp.Id, temp);
                    TrueMarkForTag.Add(temp);
                }
            }
        }

    }
}
