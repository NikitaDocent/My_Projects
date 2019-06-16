using Microsoft.EntityFrameworkCore;
using TestApp;



namespace TestApp
{
    public class UsersContext : DbContext
    {
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       
    }
}