namespace CustomerAnalyticSystem.DAL.DTOs.DTOsForPreferences
{
    public abstract class AbstractPreferenceDTO
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract bool IsInterested { get; set; }
    }
}
