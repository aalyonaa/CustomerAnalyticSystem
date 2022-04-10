using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences;

namespace CustomerAnalyticSystem.BLL.Analytics
{
    public class GroupPrefModel : PreferencesBaseAbstractModel, IDescription
    {
        public override int Id { get; set; }
        public override bool IsInterested { get; set; }
        public override string Name { get; set; }
        public string Description { get; set; }
    }
}
