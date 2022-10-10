using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlaySafe.Models
{
    public class user
    {
        [Key]
        public Guid id { get; set; }
        public Guid userTypeId { get; set; }
        [ForeignKey("userTypeId")]
        public userType userType { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
        public string phoneNum { get; set; }
    }
    public class registerViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public string phoneNum { get; set; }
    }

    public class loginViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }   
}
