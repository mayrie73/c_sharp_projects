using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class UserDashboardContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserDashboardContext(DbContextOptions<UserDashboardContext> options) : base(options) { }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts{get; set;}

    }

}