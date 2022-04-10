using CustomerAnalyticSystem.DAL.Interfaces;
using System.Collections.Generic;
namespace CustomerAnalyticSystem.DAL.DTOs
{
    class ProductWithGroupInfoWithPositionsInCheck : IBaseProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public List<GetAllProductInfoById> MoreInfoAboutProduct { get; set; }
    }
}
