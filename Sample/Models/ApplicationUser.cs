using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Sample.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Display(Name ="FullName")]
        public string? FullName { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string? PhoneNo { get; set; }


        [Required]
        [Display(Name = "Address")]
        public  string? Address { get; set; }

        [Required]
        [Display(Name = "Registration No")]
        public string? RegNo { get; set; }
    }
}
