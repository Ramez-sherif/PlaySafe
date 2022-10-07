using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class specials
    {
        public Guid ID { get; set; }
        public Guid AD_id { get; set; }

        [ForeignKey("AD_id")]
        public User_type AD_ID { get; set; }
        public string Specials { get; set; }
    }
}
