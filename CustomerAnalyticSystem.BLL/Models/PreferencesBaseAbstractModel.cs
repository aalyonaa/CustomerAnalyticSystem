namespace CustomerAnalyticSystem.BLL.Models
{
    public abstract class PreferencesBaseAbstractModel
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract bool IsInterested { get; set; }
    }
}
