using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<LOTbooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
