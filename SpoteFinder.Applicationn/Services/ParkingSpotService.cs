using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpoteFinder.Domain.Entities;
using SpoteFinder.Domain.Interfaces;

namespace SpoteFinder.Applicationn.Services
{
    public class ParkingSpotService
    {
        private readonly IParkingSpotRepository _repository;

        public ParkingSpotService(IParkingSpotRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ParkingSpot>> GetAvailableSpotsAsync(string location, decimal? maxPrice)
        {
            return await _repository.GetAvailableSpotsAsync(location, maxPrice);
        }
    }
}
