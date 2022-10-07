using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class Specials
    {
        public Guid ID { get; set; }
        public Guid AD_id { get; set; }

        [ForeignKey("AD_id")]
        public User_type user_type { get; set; }
        public string Special { get; set; }
    }
}
