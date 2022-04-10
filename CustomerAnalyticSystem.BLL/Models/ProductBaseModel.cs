namespace CustomerAnalyticSystem.BLL.Models
{
    public class ProductBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {GroupName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not ProductBaseModel)
            {
                return false;
            }

            ProductBaseModel model = (ProductBaseModel)obj;

            return
                model.Id == Id
                && model.Name == Name
                && model.Description == Description
                && model.GroupName == GroupName
                && model.GroupId == GroupId;
        }
    }
}
