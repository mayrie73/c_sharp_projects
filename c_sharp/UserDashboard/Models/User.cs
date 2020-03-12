using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserDashboard.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public User()
        {   AccessLevel = "Normal";
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }


    }
}