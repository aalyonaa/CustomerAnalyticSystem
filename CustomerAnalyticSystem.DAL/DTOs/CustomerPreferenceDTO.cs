namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CustomerPreferenceDTO
    {
        //айди пользователя,
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public int GroupId { get; set; }
        public bool IsInterested { get; set; }

    }
}
