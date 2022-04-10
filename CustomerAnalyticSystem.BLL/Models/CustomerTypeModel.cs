namespace CustomerAnalyticSystem.BLL.Models
{
    public class CustomerTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not CustomerTypeModel)
            {
                return false;
            }

            CustomerTypeModel model = (CustomerTypeModel)obj;

            return
                model.Id == Id
                && model.Name == Name;
        }
    }
}
