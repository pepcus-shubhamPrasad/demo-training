using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpoteFinder.Domain.Interfaces
{
    public interface INotificationService
    {
        Task NotifySpotAvailabilityChanged(int spotId, bool isAvailable);
        Task NotifyReservationCreated(int spotId);
    }
}
