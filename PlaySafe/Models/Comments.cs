using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class Comments
    {
        public Guid  Id { get; set; }
        public string comment { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public User user { get; set; }
        

    }
}
