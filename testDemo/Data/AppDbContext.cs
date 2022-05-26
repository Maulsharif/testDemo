using Microsoft.EntityFrameworkCore;
using testDemo.Models;
using testDemo.Models.Auth;

namespace testDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var RoleId = System.Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(new Role
            {  ID = RoleId,
               Code = "Moderator", 
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                ID = System.Guid.NewGuid(),
                UserName = "admin@com",
                Password = "admin123",
                RoleId = RoleId
            }); 
        }
    }
}
