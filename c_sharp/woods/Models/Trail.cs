using System.ComponentModel.DataAnnotations;
namespace woods.Models{
    public class Trail : BaseEntity
    {
        [Required(ErrorMessage="Trail Name is Required")]
        public string name{get;set;}

        [Required]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters")]
        public string description{get;set;}

        [Required(ErrorMessage = "Length field is required")]
     
        public int length {get;set;}

        [Required(ErrorMessage = "Elevation change field is required")]
        
        public int elevationChange{get;set;}

        [Required(ErrorMessage = "Latitude field is required")]
        public float latitude{get;set;}

        [Required(ErrorMessage = "Longitude field is required")]
        public float longitude{get;set;}
        
        [Key]
        public int id{get;set;}

    }
}