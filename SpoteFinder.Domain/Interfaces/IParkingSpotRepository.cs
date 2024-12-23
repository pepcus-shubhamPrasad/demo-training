using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpoteFinder.Domain.Entities;

namespace SpoteFinder.Domain.Interfaces
{
    public interface IParkingSpotRepository
    {
        Task<IEnumerable<ParkingSpot>> GetAvailableSpotsAsync(string location, decimal? maxPrice);
        Task<ParkingSpot> GetSpotByIdAsync(int spotId);
        Task UpdateSpotAvailabilityAsync(int spotId, bool isAvailable);
    }
}
