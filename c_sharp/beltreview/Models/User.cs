using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace beltreview.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Like> Likes {get;set;}
        public List<Idea> Ideas{get;set;}
        public User()
        {
            CreatedAt=DateTime.Now;
            Likes=new List<Like>();
            Ideas=new List<Idea>();
        }
    }
}