using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
 
namespace dojo_league.Models
{
    public class Dojo: BaseEntity
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Dojo Name is Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Dojo Location is Required")]
        public string location { get; set; }
        public string information { get; set; }
        [Key]
        public int ninjas_id { get; set; }
        public DateTime created_at { get; set; }
 
        public DateTime updated_at { get; set; }
         public ICollection<Ninja> ninjas { get; set; }
        

    }
}