using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserDashboard.Models
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public string CommentContent {get; set;}
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
