namespace CustomerAnalyticSystem.BLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not TagModel)
            {
                return false;
            }

            TagModel model = (TagModel)obj;

            return
                model.Id == Id
                && model.Name == Name;
        }
    }
}
