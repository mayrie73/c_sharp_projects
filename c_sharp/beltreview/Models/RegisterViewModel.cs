using System.ComponentModel.DataAnnotations;

namespace beltreview.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Alias is required")]
        [MinLength(2, ErrorMessage = "Alias must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
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