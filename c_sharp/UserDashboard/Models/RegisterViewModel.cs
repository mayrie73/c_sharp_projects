using System.ComponentModel.DataAnnotations;

namespace UserDashboard.Models
{
   public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(2, ErrorMessage = "First Name must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2, ErrorMessage = "Last Name must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Password Confirmation must match")]
        public string PasswordConfirmation { get; set; }

    }
    public class LoginViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]

        public string Password { get; set; }
    }
}