using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace beltreview.Models
{
    public class Like : BaseEntity
    {
        public int LikeId{get;set;}
        public int UserId{get;set;}
        public int IdeaId{get;set;}
       
        public User User{get;set;}
        public Idea Idea {get;set;}
        public Like()
        {
           CreatedAt=DateTime.Now;
        }
    }
}