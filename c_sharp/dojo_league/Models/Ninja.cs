using System;
using System.ComponentModel.DataAnnotations;

namespace dojo_league.Models

{
    public abstract class BaseEntity{}
    public class Ninja : BaseEntity
    {
        [Key]
        public int id { get; set; }
 
        [Required]
        public string name { get; set; }
 
        [Required]
        public int level { get; set; }

        [Required]
        public string location { get; set; }

        public string description{ get; set; }
 
        public DateTime created_at { get; set; }
 
        public DateTime updated_at { get; set; }
 
        public Dojo dojo { get; set; }
    }
}