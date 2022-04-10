namespace CustomerAnalyticSystem.BLL.Models
{
    public class CheckByOrderIdModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int Mark { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is not CheckByOrderIdModel)
            {
                return false;
            }

            CheckByOrderIdModel model = (CheckByOrderIdModel)obj;

            return
                model.ProductId == ProductId
                && model.ProductName == ProductName
                && model.Amount == Amount
                && model.Mark == Mark;
        }
    }
}
