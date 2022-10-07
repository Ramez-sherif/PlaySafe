using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class Match_History
    {
        public Guid Id { get; set; }
        public Guid userid { get; set; }
        [ForeignKey("userid")]
        public User User_ID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Cost { get; set; }


    }
}
