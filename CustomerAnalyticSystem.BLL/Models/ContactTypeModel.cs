namespace CustomerAnalyticSystem.BLL.Models
{
    public class ContactTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
