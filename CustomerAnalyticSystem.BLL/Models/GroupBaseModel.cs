namespace CustomerAnalyticSystem.BLL.Models
{
    public class GroupBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not GroupBaseModel)
            {
                return false;
            }

            GroupBaseModel model = (GroupBaseModel)obj;

            return
                model.Id == Id
                && model.Name == Name
                && model.Description == Description;
        }
    }

}

