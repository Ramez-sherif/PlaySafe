using System.ComponentModel.DataAnnotations;

namespace PlaySafe.Models
{
    public class User_Match
    {
        [Key]
        public int Id { get; set; }
        
        public Guid Match_ID { get; set; }
        public Guid User_Id { get; set; }
       

    }
}
