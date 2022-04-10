using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Models
{
    public class CustomerInfoModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public List<CommentModel> Comments { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {TypeId}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not CustomerInfoModel) { 
                return false;
            }
            if (Contacts.Count != ((CustomerInfoModel)obj).Contacts.Count
                || Comments.Count != ((CustomerInfoModel)obj).Comments.Count)
            {
                return false;
            }

            for (int i = 0; i < Contacts.Count; i++)
            {
                if (!Contacts[i].Equals(((CustomerInfoModel)obj).Contacts[i]))
                {
                    return false;
                }
            }

            for (int i = 0; i < Comments.Count; i++)
            {
                if (!Comments[i].Equals(((CustomerInfoModel)obj).Comments[i]))
                {
                    return false;
                }
            }

            if (Id != ((CustomerInfoModel)obj).Id
                || FirstName != ((CustomerInfoModel)obj).FirstName
                || LastName != ((CustomerInfoModel)obj).LastName
                || TypeId != ((CustomerInfoModel)obj).TypeId
                || Name != ((CustomerInfoModel)obj).Name)
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