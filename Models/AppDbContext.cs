using Microsoft.EntityFrameworkCore;

namespace ReservationProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { } 

        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
    }
}
