using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UnicornApp
{
  public class UserMetadata
  {
    private const string passRegex = "^(?=.*[A-Za-z])(?=.*?[0-9])(?=.*[$@$!%*#?&])[a-zA-Z0-9$@$!%*#?&]{8,}$";
    private const string mobileRegex = "[0-9]";
    public int Id;
    [StringLength(50)]
    [EmailAddress(ErrorMessage = "Invaild Email address.")]
    [Remote("IsExist", "User", ErrorMessage = "Email already exists.")]
    [Required]
    public string Email { get; set; }
    [StringLength(50, MinimumLength = 8)]
    [RegularExpression(passRegex, ErrorMessage = "Password should contain atleast 1 alphabet, 1 special character and 1 number.")]
    public string Password;
    [StringLength(50)]
    public string FirstName;
    [StringLength(50)]
    public string LastName;
    [StringLength(10, MinimumLength = 10)]
    [RegularExpression(mobileRegex,ErrorMessage = "10 digits mobile number only.")]
    public string Contact;
    [Required]
    public string Region;
    [Required]
    public string Image;
  }

  public class TweetMetadata
  {
    public int Id;
    [StringLength(240)]
    [Required]
    public string Body;
    [Required]
    public int UserId;
    [Required]
    public byte[] CreatedAt;
  }
}
