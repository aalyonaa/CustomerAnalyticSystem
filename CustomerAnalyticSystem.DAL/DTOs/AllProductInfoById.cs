using System.Collections.Generic;

namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class AllProductInfoById
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public List<CheckDTO> CheckForCurrentProduct { get; set; }
    }
}
