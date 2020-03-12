using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId { get; set; }
        public int UserId {get; set;}
        public string Bride { get; set; }
        public string Groom { get; set; }
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
        public string Address { get; set; }
          
        [InverseProperty("Wedding")]
        public List<GuestList> Guests { get; set; }
        public Wedding()
        {
            Guests = new List<GuestList>();
        }
    }
}