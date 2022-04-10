using System.Collections.Generic;

namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CustomerWithTagsMarks
    {
        public int CustomerID { get; set; }
        public List<TagMarksDTO> TagMarks { get; set; }
    }
}
