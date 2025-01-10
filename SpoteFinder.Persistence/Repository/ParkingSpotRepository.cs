using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpoteFinder.Domain.Entities;
using SpoteFinder.Domain.Interfaces;

namespace SpoteFinder.Persistence.Repository
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private readonly ApplicationDbContext _context;

        public ParkingSpotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParkingSpot>> GetAvailableSpotsAsync(string location, decimal? maxPrice)
        {
            var query = _context.ParkingSpots.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(p => p.Address.Contains(location));
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerHour <= maxPrice);
            }

            return await query.ToListAsync();
        }

        public async Task<ParkingSpot> GetSpotByIdAsync(int spotId)
        {
            return (await _context.ParkingSpots.FindAsync(spotId))!;
        }

        public async Task UpdateSpotAvailabilityAsync(int spotId, bool isAvailable)
        {
            var spot = await _context.ParkingSpots.FindAsync(spotId);
            if (spot != null)
            {
                spot.IsAvailable = isAvailable;
                await _context.SaveChangesAsync();
            }
        }
    }
}
