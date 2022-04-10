namespace CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences
{
    public class GroupForPrefDTO : AbstractPreferenceDTO, IDescription
    {
        public string Description { get; set; }
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override bool IsInterested { get; set; }

    }
}
