using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class Match_History
    {
        public Guid Id { get; set; }
        public Guid userid { get; set; }
        [ForeignKey("userid")]
        public User user { get; set; }
        public Guid entryid { get; set; }
        [ForeignKey("entryid")]
  
        public Entry entry { get; set; }    

        public DateTime createdDate { get; set; } = DateTime.Now;
        



    }
}
