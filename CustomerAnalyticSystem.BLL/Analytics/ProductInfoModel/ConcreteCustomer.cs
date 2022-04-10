using CustomerAnalyticSystem.BLL.Models;
using System.Collections.Generic;
using System.Linq;
using static CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel.GeneralStatistics;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{
    public class ConcreteCustomer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<int, ItemToRecommend> ProductsRecommends { get; set; }
        public Dictionary<int, ItemToRecommend> GroupsRecommends { get; set; }
        public Dictionary<int, ItemToRecommend> TagsRecommends { get; set; }



        internal GeneralStatistics InfoToAnalise { get; set; }
        internal Dictionary<int, List<int>> AllOneProductMarks { get; set; }//держит для каждого продукта список оценок кастомера
        internal Dictionary<int, int> PreferenceByProductId { get; set; }//Ключ - айди продукта, велью его преф (-1 / 1)
        internal Dictionary<int, int> PreferenceByTagId { get; set; }
        internal Dictionary<int, int> PreferenceByGroupId { get; set; }


        internal Dictionary<int, int> ProductPercent { get; set; }
        private Dictionary<int, int> ProductAvgGrade { get; set; }//key = prId, val = avgGrade
        private int AllcustomerOrders { get; set; }
        public ConcreteCustomer(GeneralStatistics info, CustomerInfoModel customer)
        {
            InfoToAnalise = info;
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            ProductsRecommends = info.Products;
            GroupsRecommends = info.Groups;
            TagsRecommends = info.Tags;
        }

        internal void AllocatePlaceesForGroupsAndTags()
        {
            List<GroupBaseModel> grps = InfoToAnalise.Info.Groups;
            foreach (var group in grps)
            {
                GroupsRecommends.Add(group.Id, new(group.Id, group.Name));
            }
            foreach (var tag in InfoToAnalise.Info.Tags)
            {
                TagsRecommends.Add(tag.Id, new(tag.Id, tag.Name));
            }
        }

        public ConcreteCustomer()
        {
            ProductsRecommends = new();
            GroupsRecommends = new();
            TagsRecommends = new();

        }

        internal void IncludeStatistics(GeneralStatistics stats)
        {
            InfoToAnalise = stats;
        }

        private int GetAvgProductMark(List<int> marks)
        {
            if (marks.Count == 1)
                return marks[0];
            else if (marks.Count == 2)
                return (marks[0] + marks[1]) / 2;
            else
                return marks[marks.Count / 2];
        }
        internal void AvgMarkForEveryProduct()
        {
            ProductAvgGrade = new();
            foreach (var c in AllOneProductMarks)
            {
                ProductAvgGrade.Add(c.Key, GetAvgProductMark(c.Value));
            }
        }
        internal void GetPopularityGroup(List<int> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i] == ((int)IsContain.Contain))
                {
                    GroupsRecommends.Values.ElementAt(i).Percent++;
                }
            }
        }

        internal void GetPopularityTag(List<int> tags)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == -555)
                {
                    TagsRecommends.Values.ElementAt(i).Percent++;
                }
            }
        }
        private enum ConvertToPercent
        {
            product = 1,
            group = 2,
            tag = 3
        };

        private void GetPercents(ConvertToPercent type)
        {
            if (AllcustomerOrders == 0)
                return;
            if (type is ConvertToPercent.group)
            {
                for (int i = 0; i < GroupsRecommends.Count; i++)
                {
                    var group = GroupsRecommends.ElementAt(i);
                    GroupsRecommends[group.Key].Percent = (GroupsRecommends[group.Key].Percent * 100) / AllcustomerOrders;
                }
            }
            else if (type is ConvertToPercent.tag)
            {
                for (int i = 0; i < TagsRecommends.Count; i++)
                {
                    var tag = TagsRecommends.ElementAt(i);
                    TagsRecommends[tag.Key].Percent = (TagsRecommends[tag.Key].Percent * 100) / AllcustomerOrders;
                }
            }
            else if (type is ConvertToPercent.product)
            {
                for (int i = 0; i < ProductsRecommends.Count; i++)
                {
                    var prod = ProductsRecommends.ElementAt(i);
                    ProductsRecommends[prod.Key].Percent = (ProductsRecommends[prod.Key].Percent * 100) / AllcustomerOrders;
                }
            }
            SetValuesToCustomerPreferences();
        }

        private void ClearEmptyItems()
        {
            foreach (var tag in TagsRecommends)
            {
                if (tag.Value.Percent == 0)
                    TagsRecommends.Remove(tag.Key);
            }
            foreach (var grp in GroupsRecommends)
            {
                if (grp.Value.Percent == 0)
                    GroupsRecommends.Remove(grp.Key);
            }
        }
        private void SetValuesToCustomerPreferences()
        {
            foreach (var group in PreferenceByGroupId)
            {
                if (group.Value == 1)
                {
                    GroupsRecommends[group.Key].AverageMark = 11;
                }
                else if (group.Value == -1)
                {
                    GroupsRecommends[group.Key].AverageMark = -1;
                }
            }
            foreach (var tag in PreferenceByTagId)
            {
                if (tag.Value == 1)
                {
                    TagsRecommends[tag.Key].AverageMark = 11;
                }
                else if (tag.Value == -1)
                {
                    TagsRecommends[tag.Key].AverageMark = -1;
                }
            }
            TakeAvgMarkForProduct();
            ClearEmptyItems();
        }

        private int AvgMarkForCurProd(List<int> prodMarks)
        {
            if (prodMarks.Count == 1)
            {
                return prodMarks[0];
            }
            else if (prodMarks.Count == 2)
            {
                return (prodMarks[0] + prodMarks[1]) / 2;
            }
            else
            {
                return (prodMarks[prodMarks.Count / 2]);
            }
        }
        private void TakeAvgMarkForProduct()
        {
            foreach (var prod in ProductsRecommends)
            {
                if (PreferenceByProductId.ContainsKey(prod.Key))
                {
                    if (PreferenceByProductId[prod.Key] == 1)
                    {
                        ProductsRecommends[prod.Key].AverageMark = 11;
                    }
                    else if (PreferenceByProductId[prod.Key] == -1)
                    {
                        ProductsRecommends[prod.Key].AverageMark = -1;
                    }
                }
                else if (AllOneProductMarks.ContainsKey(prod.Key))
                {
                    var e = AllOneProductMarks[1];
                    ProductsRecommends[prod.Key].AverageMark = AvgMarkForCurProd(AllOneProductMarks[prod.Key]);
                }
            }
        }

        internal void GetAllCurrentCustomerOrders()
        {
            int cnt = 0;
            foreach (var order in InfoToAnalise.Info.Orders)
            {
                if (order.CustomerId == this.Id)
                    cnt++;
            }
            AllcustomerOrders = cnt;
            GetPercents(ConvertToPercent.group);
            GetPercents(ConvertToPercent.tag);
            GetPercents(ConvertToPercent.product);
        }

    }
}
