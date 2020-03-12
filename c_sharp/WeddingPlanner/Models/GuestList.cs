using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models
{
    public class GuestList : BaseEntity
    {

        public int GuestListId { get; set; }
        public int UserId { get; set; }
         public int GuestId {get; set;}
        public string GuestName { get; set; }
        [ForeignKey("GuestId")]
        public User Guest { get; set; }
        public int WeddingId { get; set; }
        [ForeignKey("WeddingId")]
        public Wedding Wedding { get; set; }

        public User user { get; set; }

    }
}
