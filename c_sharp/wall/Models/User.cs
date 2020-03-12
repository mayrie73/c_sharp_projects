using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class Register : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(2, ErrorMessage = "First Name must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2, ErrorMessage = "Last Name must be more than 2 characters long")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Password Confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password and Password Confirmation must match")]
        public string password_confirm { get; set; }

    }
    public class Login : BaseEntity
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]
      
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
      
        public string password { get; set; }
    }

}