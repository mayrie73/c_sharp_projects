using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace beltreview.Models
{
    public class Idea : BaseEntity
    {
        public int IdeaId{get;set;}
        public string IdeaText {get;set;} 
        public int UserId{get;set;}
        public List<Like> Likes {get;set;}
        public User user{get;set;}
        public Idea()
        {
            CreatedAt=DateTime.Now;
            Likes=new List<Like>();
        }
    }
}