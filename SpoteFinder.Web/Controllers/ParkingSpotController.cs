using Microsoft.AspNetCore.Mvc;
using SpoteFinder.Application.Services;

namespace SpoteFinder.Web.Controllers
{
    public class ParkingSpotController(ParkingSpotService service) : Controller
    {
        private readonly ParkingSpotService _service = service;

        public async Task<IActionResult> Index(string location, decimal? maxPrice)
        {
            var spots = await _service.GetAvailableSpotsAsync(location, maxPrice);
            return View(spots);
        }

        public async Task<IActionResult> Details(int id)
        {
            var spot = await _service.GetSpotByIdAsync(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }
    }
}
