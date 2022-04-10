namespace CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences
{
    public class ProductForPrefDTO : AbstractPreferenceDTO, IDescription
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override bool IsInterested { get; set; }
        public string Description { get; set; }

    }
}
