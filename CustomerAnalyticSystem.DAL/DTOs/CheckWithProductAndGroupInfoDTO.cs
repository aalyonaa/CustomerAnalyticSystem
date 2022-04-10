namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CheckWithProductAndGroupInfoDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public int Amount { get; set; }
        public int Mark { get; set; }
    }
}
