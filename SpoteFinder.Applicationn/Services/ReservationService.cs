using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpoteFinder.Domain.Entities;
using SpoteFinder.Domain.Interfaces;
using SpoteFinder.Web.Hubs;

namespace SpoteFinder.Applicationn.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IParkingSpotRepository _spotRepository;
        private readonly IHubContext<ParkingSpotHub> _hubContext;

        public ReservationService(
            IReservationRepository reservationRepository,
            IParkingSpotRepository spotRepository,
            IHubContext<ParkingSpotHub> hubContext)
        {
            _reservationRepository = reservationRepository;
            _spotRepository = spotRepository;
            _hubContext = hubContext;
        }

        public async Task<Reservation> CreateReservationAsync(int spotId, DateTime startTime, DateTime endTime)
        {
            var spot = await _spotRepository.GetSpotByIdAsync(spotId);
            if (spot == null || !spot.IsAvailable)
            {
                throw new Exception("Parking spot not available.");
            }

            var reservation = new Reservation
            {
                SpotId = spotId,
                StartTime = startTime,
                EndTime = endTime,
                Status = ReservationStatus.Pending
            };

            await _reservationRepository.CreateReservationAsync(reservation);
            await _spotRepository.UpdateSpotAvailabilityAsync(spotId, false);

            // Notify clients about changes
            await _hubContext.Clients.All.SendAsync("SpotAvailabilityChanged", spotId, false);
            await _hubContext.Clients.All.SendAsync("ReservationCreated", reservation);

            return reservation;
        }
    }
}
