using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace PlaySafe.Models
{
    public class User
    {
        [Key]
        public Guid user_Id { get; set; }
        public Guid u_Typeid { get; set; }

        [ForeignKey("u_Typeid")]
        public User_type user_type { get; set; }
        [Required]
        public string name { get; set; }
        public string nserName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public DateTime createdDate { get; set; } = DateTime.Now;
        public string phone_Num { get; set; }
        
     
    
    }
    public class loginViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }

        public string u_Type { get; set; }


    }



}
