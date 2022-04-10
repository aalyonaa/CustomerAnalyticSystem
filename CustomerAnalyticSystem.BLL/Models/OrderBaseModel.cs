namespace CustomerAnalyticSystem.BLL.Models
{
    public class OrderBaseModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public int Cost { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not OrderBaseModel)
            {
                return false;
            }

            OrderBaseModel model = (OrderBaseModel)obj;

            return
                model.Id == Id
                && model.Date == Date
                && model.CustomerId == CustomerId
                && model.FirstName == FirstName
                && model.LastName == LastName
                && model.Status == Status
                && model.Cost == Cost;
        }
    }
}
