namespace CustomerAnalyticSystem.BLL.Models
{
    public class CheckBaseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public int Mark { get; set; }
    }
}
