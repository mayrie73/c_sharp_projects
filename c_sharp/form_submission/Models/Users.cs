using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(4, ErrorMessage = "First Name must be more than 4 characters long")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(4, ErrorMessage = "Last Name must be more than 4 characters long")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a number greater than 0")]
        public int age { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address must be valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
