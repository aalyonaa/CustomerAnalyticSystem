using System;

namespace CustomerAnalyticSystem.BLL.Models
{
    public class GradeBaseModel : IComparable
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            GradeBaseModel toCompare = (GradeBaseModel)obj;
            if (this.ProductId > toCompare.ProductId)
                return 1;
            if (this.ProductId < toCompare.ProductId)
                return -1;
            return 0;
        }
    }
}
