using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace beltreview.Models
{
    public class BeltReviewContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltReviewContext(DbContextOptions<BeltReviewContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Idea> Ideas { get; set; }


    }

}