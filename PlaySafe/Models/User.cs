using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PlaySafe.Models
{
    public class User
    {
        [Key]
        public Guid User_Id { get; set; }
        public string UserName { get; set; }
        public string Phone_Num { get; set; }
        public string Password { get; set; }
    
        public string Pic { get; set; }
    
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Points { get; set; } = 0;

    }
}
