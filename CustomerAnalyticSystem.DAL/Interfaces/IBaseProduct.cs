namespace CustomerAnalyticSystem.DAL.Interfaces
{
    public interface IBaseProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
    }
}
