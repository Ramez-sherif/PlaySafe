using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlaySafe.Models
{
    public class Matches
    {
        [Key]
        public Guid Match_ID { get; set; }
        public int Cost { get; set; }
        public DateTime Date { get; set; }

    }
}
