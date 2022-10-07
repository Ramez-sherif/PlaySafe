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
        public Guid User_Id { get; set; }
        public Guid Admin_ID { get; set; }
        [Required]
        public Guid U_Typeid { get; set; }

        [ForeignKey("U_Typeid")]
        public User_type USer_type { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Pic { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Phone_Num { get; set; }
        public int Points { get; set; } = 0;
    
    

    }
    public class loginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string U_Type { get; set; }


    }



}
