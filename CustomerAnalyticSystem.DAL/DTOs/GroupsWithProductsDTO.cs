using System.Collections.Generic;

namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class GroupsWithProductsDTO : GroupBaseDTO
    {
        public List<ProductBaseDTO> Products { get; set; }
    }
}
