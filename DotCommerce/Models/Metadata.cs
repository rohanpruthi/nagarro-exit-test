using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotCommerce.Models
{
    public class PersonMetadata
    {   
        [StringLength(50)]
        [Required]
        public string FirstName;
        [StringLength(50)]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsExist", "Person", ErrorMessage = "Email already exists")]
        public string Email { get; set; }
        [StringLength(15)]
        [Required]
        public string Password;
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage ="Password doesn't match")]
        public string CPassword { get; set; }
    }

    public class ProductMetadata
    {
    }

}