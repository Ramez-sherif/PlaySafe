using System.ComponentModel.DataAnnotations;

namespace PlaySafe.Models
{
    public class User_type
    {
        [Key]
        public Guid Id { get; set; } 
        public string user_Type { get; set; }
    }
}
