using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class player
    {
        [Key]
        public Guid player_Id { get; set; }
        public Guid userid { get; set; }

        [ForeignKey("userid")]
        public User user { get; set; }
        public Guid admin_ID { get; set; }
        [Required]
        public string pic { get; set; }
        [Required]
        public int points { get; set; } = 0;


    }
}
