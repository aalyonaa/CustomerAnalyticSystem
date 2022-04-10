namespace CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences
{
    public class TagForPrefDTO : AbstractPreferenceDTO
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override bool IsInterested { get; set; }

    }
}
