using Microsoft.EntityFrameworkCore;
using testDemo.Models;

namespace testDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Flight> Flights { get; set; }
    }
}
