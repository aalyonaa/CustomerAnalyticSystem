namespace CustomerAnalyticSystem.BLL.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not StatusModel)
            {
                return false;
            }

            StatusModel model = (StatusModel)obj;

            return
                model.Id == Id
                && model.Name == Name;
        }
    }
}
