using AutoMapper;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel
{
    public class GeneralStatistics
    {
        // в общую сводку: три листа Products;Groups;Tags Оттуда вся инфа для заполнения
        public enum IsContain { Contain = -555 };
        private enum ConvertToPercent
        {
            product = 1,
            group = 2,
            tag = 3
        };
        public StackModel Info;

        //словарь рекомендаций
        public Dictionary<int, ItemToRecommend> Products { get; set; }//в общей сво
        public Dictionary<int, ItemToRecommend> Groups { get; set; }//
        public Dictionary<int, ItemToRecommend> Tags { get; set; }


        //словарь который соотносит все теги с продуктом и группы с продуктом
        public Dictionary<int, List<int>> ProductsByTagId { get; set; }//key = tagId value = product Ids
        public Dictionary<int, List<int>> GroupsByProductId { get; set; }

        //словарь соотносит айди чека с ордером
        public Dictionary<int, List<int>> ChecksInOrder { get; set; }
        public Dictionary<int, int> CheckProduct { get; set; }


        public int AmountOfOrders { get; set; }

        public GeneralStatistics()
        {

            StackModel allLists;
            ProductService dtos = new();
            allLists = dtos.GetAllInfoAboutAll();
            Info = allLists;
            Products = new();
            Groups = new();
            Tags = new();
            AmountOfOrders = Info.Orders.Count;
            MakeStatistics();
        }
        private void MakeStatistics()
        {
            FillProducts();
            FillGroups();
            FillTags();
            GetListOfAllTagsInProduct();
            GetListOfAllGroupsInProduct();
            PutAllCheckByOrders();
            FindAllBestsellers();
        }
        public MapperConfiguration configuration = new(cfg =>
        {
            cfg.CreateMap<ProductBaseModel, ItemToRecommend>();
            cfg.CreateMap<GroupBaseModel, ItemToRecommend>();
            cfg.CreateMap<TagModel, ItemToRecommend>();
        });

        #region fill sht
        public void FillProducts()// все продукты
        {
            foreach (var product in Info.Products)
            {
                if (Products.ContainsKey(product.Id) == false)
                {
                    var map = new Mapper(configuration)
                        .Map<ProductBaseModel, ItemToRecommend>(product);
                    Products.Add(map.Id, map);
                }
            }
        }
        public void FillGroups()//все группы
        {
            foreach (var group in Info.Groups)
            {
                if (Groups.ContainsKey(group.Id) == false)
                {
                    var map = new Mapper(configuration)
                        .Map<GroupBaseModel, ItemToRecommend>(group);
                    Groups.Add(map.Id, map);
                }

            }
        }

        public void FillTags()//заполняет все теги
        {
            foreach (var tag in Info.Tags)
            {
                if (Tags.ContainsKey(tag.Id) == false)
                {
                    var map = new Mapper(configuration)
                        .Map<TagModel, ItemToRecommend>(tag);
                    Tags.Add(map.Id, map);
                }
            }
        }
        #endregion

        #region связка продуктов
        public void GetListOfAllTagsInProduct() //связывает теги в группы
        {
            ProductsByTagId = new();
            foreach (var c in Info.Product_Tag)
            {
                if (ProductsByTagId.ContainsKey(c.TagId) == false)
                {
                    ProductsByTagId.Add(c.TagId, new());
                }
                ProductsByTagId[c.TagId].Add(c.ProductId);
            }
        }

        public void GetListOfAllGroupsInProduct()//связывает продукты в группы
        {
            GroupsByProductId = new();
            foreach (var product in Info.Products)
            {
                if (GroupsByProductId.ContainsKey(product.GroupId) == false)
                {
                    GroupsByProductId.Add(product.GroupId, new());
                }
                GroupsByProductId[product.GroupId].Add(product.Id);
            }
        }

        public void PutAllCheckByOrders()// связывает все чеки с ордерами
        {
            ChecksInOrder = new();
            foreach (var check in Info.Checks)
            {
                if (ChecksInOrder.ContainsKey(check.OrderId) == false)
                {
                    ChecksInOrder.Add(check.OrderId, new());
                }
                ChecksInOrder[check.OrderId].Add(check.Id);
            }
        }
        public void BoundCheckProduct()// связывает айди чека с айдипродукта
        {
            CheckProduct = new();
            foreach (var check in Info.Checks)
            {
                CheckProduct.Add(check.Id, check.ProductId);
            }
        }
        #endregion

        internal bool IsContains(int id, int prodId)//проверка на появление продукта в заказе (по чеку)
        {
            List<int> oneOrder;

            if (ChecksInOrder.ContainsKey(id) == false)
            {
                return false;
            }
            for (int i = 0; i < ChecksInOrder[id].Count; i++)
            {
                oneOrder = ChecksInOrder[id];
                if (CheckProduct[oneOrder[i]] == prodId)
                {
                    return true;
                }
            }
            return false;
        }
        private void ConvertToPercents(ConvertToPercent type)
        {
            if (type is ConvertToPercent.product)
            {
                foreach (var prod in Products)
                {
                    prod.Value.Percent = (prod.Value.Percent * 100) / AmountOfOrders;
                }
            }
            else if (type is ConvertToPercent.group)
            {
                foreach (var group in Groups)
                {
                    group.Value.Percent = (group.Value.Percent * 100) / AmountOfOrders;
                }
            }
            else if (type is ConvertToPercent.tag)
            {
                foreach (var tag in Tags)
                {
                    tag.Value.Percent = (tag.Value.Percent * 100) / AmountOfOrders;
                }
            }
        }
        internal int GetMark(int productId, List<GradeBaseModel> grades, int curIndex)
        {
            List<int> allProductGrades = new();
            while (curIndex < grades.Count && grades[curIndex].ProductId == productId)
            {
                allProductGrades.Add(grades[curIndex].Value);
                curIndex++;
            }
            if (allProductGrades.Count == 1)
            {
                Products[productId].AverageMark = allProductGrades[0];
            }
            else if (allProductGrades.Count > 1)
            {
                Products[productId].AverageMark = allProductGrades[allProductGrades.Count / 2];
            }
            return curIndex;
        }
        private void AvgGrade()
        {
            List<GradeBaseModel> temp = Info.Grades;
            temp.Sort();
            int cnt = 0;
            int gradeIndex = 0;
            ItemToRecommend tempw;
            while (cnt < Products.Count)
            {
                tempw = Products.Values.ElementAt(cnt);
                gradeIndex = GetMark(tempw.Id, temp, gradeIndex);
                if (gradeIndex >= temp.Count)
                {
                    return;
                }
                cnt++;
            }
        }

        public void ComparingTagAndProduct(List<int> tags, int prodId)
        {
            foreach (var c in Info.Product_Tag)
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    if (c.ProductId == prodId && c.TagId == tags[i])
                    {
                        tags[i] = ((int)IsContain.Contain);
                    }
                }
            }
        }
        public void ComparingGroupAndProduct(List<int> groups, int prodId)
        {
            foreach (var c in Info.Products)
            {
                for (int i = 0; i < groups.Count; i++)
                {
                    if (c.Id == prodId && c.GroupId == groups[i])
                    {
                        groups[i] = ((int)IsContain.Contain);
                    }
                }
            }
        }
        public void GetPopularityGroup(List<int> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i] == ((int)IsContain.Contain))
                {
                    Groups.Values.ElementAt(i).Percent++;
                }
            }
        }

        public void GetPopularityTag(List<int> tags)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == ((int)IsContain.Contain))
                {
                    Tags.Values.ElementAt(i).Percent++;
                }
            }
        }
        public void FindAllBestsellers()//количество появления продукта в каждом заказе
        {
            BoundCheckProduct();

            List<int> isContainTag;
            List<int> isContainGroup;

            foreach (var order in Info.Orders)
            {
                isContainGroup = Groups.Keys.ToList();
                isContainTag = Tags.Keys.ToList();
                foreach (var prod in Products)
                {
                    if (IsContains(order.Id, prod.Key))
                    {
                        prod.Value.Percent++;
                        ComparingTagAndProduct(isContainTag, prod.Key);
                        ComparingGroupAndProduct(isContainGroup, prod.Key);
                    }
                }
                GetPopularityGroup(isContainGroup);
                GetPopularityTag(isContainTag);
            }
            AvgGrade();
            ConvertToPercents(ConvertToPercent.product);
            ConvertToPercents(ConvertToPercent.group);
            ConvertToPercents(ConvertToPercent.tag);
        }
    }
}
