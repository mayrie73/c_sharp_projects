using System;
using System.ComponentModel.DataAnnotations;
namespace restauranter.Models
{   public abstract class BaseEntity{}
    public class Review : BaseEntity
    {
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Reviewer Name is required")]
        public string ReviewerName { get; set; }

        [Required(ErrorMessage = "Restaurant Name is required")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Restaurant Review is required")]
        [MinLength(10, ErrorMessage = "Restaurant Review must be more than 10 characters long")]
        public string RestaurantReview { get; set; }

        [DataType(DataType.Date)]
        public DateTime  DateOfVisit { get; set; }
        
        [Required(ErrorMessage = "Review Rating is required")]
        public int Stars { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
      