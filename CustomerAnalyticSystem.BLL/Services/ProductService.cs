using CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Services
{
    public class ProductService
    {
        protected IProductRepository _rep = new ProductRepository();

        public ProductService(IProductRepository rep = null)
        {
            if (rep is not null)
            {
                _rep = rep;
            }
        }

        #region tag crud
        public List<TagModel> GetAllTags()
        {
            BestMapper map = new();
            var dto = _rep.GetAllTags();
            List<TagModel> result = map.MapFromTagDTOToTagModel(dto);
            return result;
        }

        public void UpdateTagById(int id, string name)
        {
            BestMapper map = new();
            _rep.UpdateTagById(id, name);
        }

        public void DeleteTagById(int id)
        {
            BestMapper map = new();
            _rep.DeleteTagById(id);
        }

        public void AddTag(string name)
        {
            BestMapper map = new();
            _rep.AddTag(name);
        }

        #endregion

        #region product crud
        public void UpdateProductById(int id, string name, string description, int groupId)
        {
            BestMapper map = new();
            _rep.UpdateProductById(id, name, description, groupId);
        }

        public void AddProduct(string name, string description, int groupId)
        {
            BestMapper map = new();
            _rep.AddProduct(name, description, groupId);
        }

        public List<ProductBaseModel> GetAllProducts()
        {
            BestMapper map = new();
            var dto = _rep.GetAllProductsWithGroups();
            var result = map.MapFromProductBaseDTOToProductBaseModel(dto);
            return result;
        }

        public void DeleteProductById(int id)
        {
            BestMapper map = new();
            _rep.DeleteProductById(id);
        }

        #endregion     

        #region group crud
        public List<GroupBaseModel> GetAllGroups()
        {
            BestMapper map = new();
            var dto = _rep.GetAllGroup();
            List<GroupBaseModel> result = map.MapFromGroupBaseDTOToGroupBaseModel(dto);
            return result;
        }

        public void UpdateGroupById(int id, string name, string description)
        {
            BestMapper map = new();
            _rep.UpdateGroupById(id, name, description);
        }

        public void AddGroup(string name, string description)
        {
            BestMapper map = new();
            _rep.AddGroup(name, description);
        }

        public void DeleteGroupById(int id)
        {
            BestMapper map = new();
            _rep.DeleteGroupById(id);
        }

        #endregion

        #region product tag crud

        public void UpdateProductTag(int id, int productId, int tagId)
        {
            BestMapper map = new();
            _rep.UpdateProduct_TagById(id, productId, tagId);
        }

        public void AddProductTag(int productId, int tagId)
        {
            BestMapper map = new();
            _rep.AddProduct_Tag(productId, tagId);
        }

        public void DeleteProductTag(int id)
        {
            BestMapper map = new();
            _rep.DeleteProduct_TagById(id);
        }

        #endregion

        public List<ProductBaseModel> GetAllProductsByTagId(int id)
        {
            BestMapper map = new();
            var dto = _rep.GetAllProductsByTag(id);
            var result = map.MapFromProductBaseDTOToProductBaseModel(dto);
            return result;
        }

        public List<ProductBaseModel> GetAllProductsByGroupId(int id)
        {
            BestMapper map = new();
            var dto = _rep.GetAllProductsByGroupId(id);
            var result = map.MapFromProductBaseDTOToProductBaseModel(dto);
            return result;
        }

        public List<TagModel> GetAllTagsByProductId(int id)
        {
            BestMapper map = new();
            var dto = _rep.GetAllTagsByProductId(id);
            List<TagModel> result = map.MapFromTagDTOToTagModel(dto);
            return result;
        }

        public void DeleteProduct_TagByTagIdAndProductId(int idP, int idT)
        {
            BestMapper map = new();
            _rep.DeleteProduct_TagByTagIdAndProductId(idP, idT);
        }

        public List<GroupsWithProductsModel> GetAllGroupsWithProducts()
        {
            BestMapper map = new();
            var dto = _rep.GetAllGroupsWithProducts();
            List<GroupsWithProductsModel> result = map.MapGroupsWithProducts(dto);
            return result;
        }

        public StackModel GetAllInfoAboutAll()
        {
            BestMapper map = new();
            var dto = _rep.GetAllInfo();
            StackModel result = map.GetAllInfoForProductAnalise(dto);
            return result;
        }
    }
}
