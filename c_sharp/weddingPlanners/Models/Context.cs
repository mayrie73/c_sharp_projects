using Microsoft.EntityFrameworkCore;

namespace weddingPlanners.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<User> Users {get; set;}
        
        public DbSet<Wedding> Weddings {get; set;}
        
        public DbSet<GuestConnection> GuestConnections {get; set;}



    }
    
}