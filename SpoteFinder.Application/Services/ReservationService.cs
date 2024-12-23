using Microsoft.AspNetCore.SignalR;
using SpoteFinder.Domain.Entities;
using SpoteFinder.Domain.Interfaces;

namespace SpoteFinder.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IParkingSpotRepository _spotRepository;
        private readonly INotificationService _notificationService;

        public ReservationService(
            IReservationRepository reservationRepository,
            IParkingSpotRepository spotRepository,
            INotificationService notificationService)
        {
            _reservationRepository = reservationRepository;
            _spotRepository = spotRepository;
            _notificationService = notificationService;
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

            // Use the notification service for real-time updates
            await _notificationService.NotifySpotAvailabilityChanged(spotId, false);
            //await _notificationService.NotifyReservationCreated(spotId);

            return reservation;
        }
    }
}
