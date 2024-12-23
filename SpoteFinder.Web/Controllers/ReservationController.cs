using Microsoft.AspNetCore.Mvc;
using SpoteFinder.Application.Services;
using SpoteFinder.Domain.Entities;

namespace SpoteFinder.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Book(int spotId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var reservation = await _reservationService.CreateReservationAsync(spotId, startTime, endTime);
                return RedirectToAction("ReservationSuccess", "Reservation", new { id = reservation.ReservationId });
            }
            catch (Exception ex)
            {
                // Display error message on failure
                TempData["Error"] = ex.Message;
                return RedirectToAction("Details", "ParkingSpot", new { id = spotId });
            }
        }

        public IActionResult ReservationSuccess(int id)
        {
            ViewBag.ReservationId = id;
            return View();
        }
    }
}
