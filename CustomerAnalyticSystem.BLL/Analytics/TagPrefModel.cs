using CustomerAnalyticSystem.BLL.Models;

namespace CustomerAnalyticSystem.BLL.Analytics
{
    public class TagPrefModel : PreferencesBaseAbstractModel
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override bool IsInterested { get; set; }
    }
}
