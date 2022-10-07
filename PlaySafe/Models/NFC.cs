using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySafe.Models
{
    public class NFC
    {
        public Guid NFCId { get; set; }
        public Guid Userid { get; set; }
        [ForeignKey("Userid")]
        public User UserID { get; set; }

    }
}
