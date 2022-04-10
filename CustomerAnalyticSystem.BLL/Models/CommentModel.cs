namespace CustomerAnalyticSystem.BLL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Text}";
        }

        public override bool Equals(object obj)
        {
            if (Id != ((CommentModel)obj).Id
                || Text != ((CommentModel)obj).Text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
