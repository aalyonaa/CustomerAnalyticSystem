using System.Collections.Generic;


namespace CustomerAnalyticSystem.DAL.DTOs
{
    public class CustomerInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public List<ContactWithContactTypeNameDTO> Contacts { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {TypeId}";
        }
    }
}
