using System;
using System.Collections.Generic;
using System.Linq;
using SpoteFinder.Domain.Entities;
using SpoteFinder.Domain.Interfaces;

namespace SpoteFinder.Application.Services
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
        public async Task<ParkingSpot> GetSpotByIdAsync(int spotId)
        {
            return await _repository.GetSpotByIdAsync(spotId);
        }
    }
}
