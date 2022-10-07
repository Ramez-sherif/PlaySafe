using System.ComponentModel.DataAnnotations;

namespace PlaySafe.Models
{
    public class User_type
    {
        [Key]
        public Guid Id { get; set; } 
        public string User_Type { get; set; }
    }
}
