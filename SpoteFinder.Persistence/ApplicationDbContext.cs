using Microsoft.EntityFrameworkCore;
using SpoteFinder.Domain.Entities;

namespace SpoteFinder.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


    }
}
