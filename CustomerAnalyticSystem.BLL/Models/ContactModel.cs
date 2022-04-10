namespace CustomerAnalyticSystem.BLL.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} {Value}";
        }

        public override bool Equals(object obj)
        {
            if (Id != ((ContactModel)obj).Id
                || Value != ((ContactModel)obj).Value
                || Name != ((ContactModel)obj).Name)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
