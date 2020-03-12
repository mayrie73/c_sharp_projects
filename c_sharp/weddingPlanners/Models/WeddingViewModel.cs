using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanners.Models
{
    public class WeddingViewModel : BaseEntity{
        [Required]
        [Display(Name= "Spouse One")]
        public string SpouseOne {get; set;}

        [Required]
        [Display(Name= "Spouse Two")]

        public string SpouseTwo {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date {get; set;}

        [Required]
        [Display(Name= "Address")]

        public string Address {get; set;}
        public int UserId {get; set;}
        public int WeddingId {get; set;}
    }
    
}