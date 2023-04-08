using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Users
{
    public class UserCreationDto
    {
        [Required(ErrorMessage ="Please Enter Your name")]
        [MaxLength(30),MinLength(2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [MaxLength(30), MinLength(2)]
        [DisplayName("Last Name")]

        public string LastName { get; set; } = string.Empty;

        [Required,EmailAddress]
        [DisplayName("Email")]

        public string Email { get; set; } = string.Empty;
        [Required,MinLength(8)]
        [DisplayName("Password")]
        public string Password { get; set; } = string.Empty;
    }
}
