using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Required(ErrorMessage = "The Bride's name is required.")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        [MinLength(2, ErrorMessage = "Bride's Name must be more than 2 characters long")]
        public string Bride { get; set; }

        [Required(ErrorMessage = "The Groom's name is required.")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        [MinLength(2, ErrorMessage = "Groom's Name must be more than 2 characters long")]
        public string Groom { get; set; }

        [Required(ErrorMessage = "Wedding date is required.")]
        [FutureDate]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }
        public int UserId { get; set; }
        public int WeddingId { get; set; }

      
    }

}