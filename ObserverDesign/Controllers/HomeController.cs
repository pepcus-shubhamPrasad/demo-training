using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ObserverDesign.Deparments;
using ObserverDesign.Models;
using ObserverDesign.Subject;

namespace ObserverDesign.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAsset _it;
        private readonly IFinance _finance;
        private readonly IResignation  _Resignation;
        private readonly IHR  _ihr;
        private readonly Imanager  _imanager;

        public HomeController(Imanager imanager , IFinance finance, IAsset it , IResignation resignation , IHR ihr)
        {
            _finance = finance;
            _it = it;
            _Resignation = resignation;
            _ihr = ihr;
            _imanager = imanager;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult ITDept()
        {
            _it.AllocateAsset();
            ViewBag.Dept = "IT - Allocated Assets";
            return View("Index");
        }

        public IActionResult Finance()
        {
            _finance.CalculateSalary();
            ViewBag.Dept = "Finance - Calclulate Salery";
            return View("Index");
        }

        public IActionResult Hr()
        {
            _ihr.HrLocated();
            ViewBag.Dept = "HR - Calclulate Saleryq";
            return View("Index");
        }

        public IActionResult Manager()
        {
            _imanager.AllocateImanager();
            ViewBag.Dept = "Manager - Task Completed";
            return View("Index");
        }
        public IActionResult EmployeeSeprate(string EmployeeID)
        {
            _Resignation.NotifyObserver(EmployeeID);
            return View("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
