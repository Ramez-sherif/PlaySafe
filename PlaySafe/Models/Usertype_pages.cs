using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class Usertype_pages
    {
        [Key]
        public Guid ID { get; set; }
        public Guid userTypeid { get; set; }
        [ForeignKey("userTypeid")]
        public User_type userTypeID { get; set; }
        public int pages { get; set; }


    }
}
