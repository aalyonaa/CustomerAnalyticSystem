using CustomerAnalyticSystem.DAL.Interfaces;

namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class ProductBaseDTO : IBaseProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }


        //public override string ToString()
        //{
        //    string s = "";
        //    s += Id + " " + Name + " " + Description + " " + GroupId;
        //    return s;
        //}
    }

}