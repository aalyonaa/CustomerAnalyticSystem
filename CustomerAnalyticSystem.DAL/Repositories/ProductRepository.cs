using CustomerAnalyticSystem.DAL.DTOs;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences.ForProduct;
using CustomerAnalyticSystem.DAL.RepInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace CustomerAnalyticSystem.DAL
{
    public class ProductRepository : IProductRepository
    {
        #region Product
        public void AddProduct(string name, string description, int groupId)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.AddProduct, new { Name = name, Description = description, GroupId = groupId }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProductById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.DeleteProductById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductsWithGroupsDTO> GetAllProductsWithGroups()
        {
            string connectionString = ConnectionString.Connection;
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<ProductsWithGroupsDTO>(Queries.GetAllProductsWithGroups, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ProductBaseDTO GetProductById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingle<ProductBaseDTO>(Queries.GetProductById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateProductById(int id, string name, string description, int groupId)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.UpdateProductById, new { id = id, name = name, description = description, groupId = groupId }, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        public AllProductInfoById FillAllProductById(int id)
        {
            AllProductInfoById concreteProduct = null;


            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query<AllProductInfoById, CheckWithCustomerInfoDTO, AllProductInfoById>(Queries.GetAllProductInfoById,
                    (productInfo, check) =>
                    {
                        if (concreteProduct == null)
                        {
                            concreteProduct = productInfo;
                            concreteProduct.CheckForCurrentProduct = new();
                        }
                        concreteProduct.CheckForCurrentProduct.Add(check);
                        return concreteProduct;
                    }
                , new { Id = id }
                , commandType: CommandType.StoredProcedure
                , splitOn: "Id");
            }
            return concreteProduct;

        }

        public List<TagDTO> GetAllTags()
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<TagDTO>(Queries.GetAllTags, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void DeleteTagById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.DeleteTagById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public TagDTO GetTagById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingle<TagDTO>(Queries.GetTagById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateTagById(int id, string name)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.UpdateTagById, new { id, name }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddTag(string name)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.AddTag, new { name }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductsWithGroupsDTO> GetAllProductsByTag(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<ProductsWithGroupsDTO>(Queries.GetAllProductsByTag, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<GroupsWithProductsDTO> GetAllGroupsWithProducts()
        {
            int count = 0;
            string groupName = null;
            List<GroupsWithProductsDTO> allGroupsWithProducts = null;
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query<GroupsWithProductsDTO, ProductBaseDTO, GroupsWithProductsDTO>(Queries.GetAllGroupsWithProduct,
                    (group, product) =>
                    {
                        if (allGroupsWithProducts == null)
                        {
                            allGroupsWithProducts = new();
                            allGroupsWithProducts.Add(group);
                            allGroupsWithProducts[count].Products = new();
                            groupName = group.Name;
                        }
                        if (groupName != group.Name)
                        {
                            allGroupsWithProducts.Add(group);
                            groupName = group.Name;
                            count++;
                            allGroupsWithProducts[count].Products = new();
                        }
                        allGroupsWithProducts[count].Products.Add(product);
                        return allGroupsWithProducts[count];
                    }
                    , splitOn: "Id"
                    , commandType: CommandType.StoredProcedure);
            }
            return allGroupsWithProducts;
        }

        public void AddProduct_Tag(int productId, int tagId)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.AddProduct_Tag, new { productId, tagId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProduct_TagById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.DeleteProduct_Tag, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Product_TagDTO> GetAllProduct_Tag()
        {
            string connectionString = ConnectionString.Connection;
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<Product_TagDTO>(Queries.GetAllProduct_Tag, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public Product_TagDTO GetProduct_TagById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingle<Product_TagDTO>(Queries.GetProduct_TagById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateProduct_TagById(int id, int productId, int tagId)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.UpdateProduct_TagById, new { id, productId, tagId }, commandType: CommandType.StoredProcedure);
            }
        }
        #region Group

        public void AddGroup(string name, string description)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.AddGroup, new { name, description }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<GetNumberOfTagsInOrderByCustomerIdDTO> GetNumberOfTagsInOrderByCustomerId(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<GetNumberOfTagsInOrderByCustomerIdDTO>(Queries.GetNumberOfTagsInOrderByCustomerId
                    , new { id }, commandType: CommandType.StoredProcedure).ToList();

            }

        }

        public List<GroupBaseDTO> GetAllGroup()
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<GroupBaseDTO>(Queries.GetAllGroup, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public GroupBaseDTO GetGroupById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingle<GroupBaseDTO>(Queries.GetGroupById, new { id = id }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteGroupById(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.DeleteGroupById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateGroupById(int id, string name, string description)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query<GroupBaseDTO>(Queries.UpdateGroupById, new { Id = id, name = name, description = description }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateGroupById(GroupBaseDTO updatedGroup)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query<GroupBaseDTO>(Queries.UpdateGroupById, new
                {
                    Id = updatedGroup.Id,
                    name = updatedGroup.Name
                    ,
                    description = updatedGroup.Description
                }
                , commandType: CommandType.StoredProcedure);
            }
        }

        public void AddGroup(GroupBaseDTO newGroup)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.AddGroup, new { Name = newGroup.Name, description = newGroup.Description }
                , commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        public List<ProductBaseDTO> GetAllProduct()
        {
            string connectionString = ConnectionString.Connection;
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<ProductBaseDTO>(Queries.GetAllProduct, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        #region LogicProduct
        public List<CountTagsInAllOrdersDTO> GetTagPopularity()
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<CountTagsInAllOrdersDTO>(Queries.CountAllTagsInOrders, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public List<CountProductsInAllOrdersDTO> GetProductPopularity()
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<CountProductsInAllOrdersDTO>(Queries.CountAllProductsInOrders, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public StackDTO GetAllInfo()
        {
            StackDTO result = new();
            var tmp = new OrderRepository();
            var tmp2 = new PreferencesRepository();

            result.Groups = GetAllGroup();
            result.Tags = GetAllTags();
            result.Product_Tag = GetAllProduct_Tag();
            result.Products = GetAllProduct();
            result.Orders = tmp.GetAllOrders();
            result.Checks = tmp.GetAllCheck();
            result.Grades = tmp2.GetAllGrades();
            return result;
        }
        #endregion

        public List<ProductsWithGroupsDTO> GetAllProductsByGroupId(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<ProductsWithGroupsDTO>(Queries.GetAllProductsByGroupId, new { id }
                , commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TagDTO> GetAllTagsByProductId(int id)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<TagDTO>(Queries.GetAllTagsByProductId, new { id }
                , commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public void DeleteProduct_TagByTagIdAndProductId(int idP, int idT)
        {
            string connectionString = ConnectionString.Connection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(Queries.DeleteProduct_TagByTagIdAndProductId, new { IdProduct = idP, Id = idT }
                , commandType: CommandType.StoredProcedure);
            }
        }
    }
}
