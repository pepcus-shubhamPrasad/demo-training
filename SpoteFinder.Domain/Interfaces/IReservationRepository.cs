using SpoteFinder.Domain.Entities;

namespace SpoteFinder.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
    }
}
    