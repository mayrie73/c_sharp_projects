using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDashboard.Models
{
    public class Post : BaseEntity
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CommentId { get; set; }
        public Comment Comment { get; set; }
        public List<Post> Posts { get; set; }
   
    }
}