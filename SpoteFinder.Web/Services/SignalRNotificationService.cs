using Microsoft.AspNetCore.SignalR;
using SpoteFinder.Domain.Interfaces;
using SpoteFinder.Web.Hubs;

namespace SpoteFinder.Web.Services
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<ParkingSpotHub> _hubContext;

        public SignalRNotificationService(IHubContext<ParkingSpotHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifySpotAvailabilityChanged(int spotId, bool isAvailable)
        {
            await _hubContext.Clients.All.SendAsync("SpotAvailabilityChanged", spotId, isAvailable);
        }

        public async Task NotifyReservationCreated(int spotId)
        {
            await _hubContext.Clients.All.SendAsync("ReservationCreated", spotId);
        }
    }
}
