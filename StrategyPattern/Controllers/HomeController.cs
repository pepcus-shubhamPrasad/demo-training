using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StrategyPattern.BusinessService;
using StrategyPattern.Models;

namespace StrategyPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string cardType)
        {
            if (!string.IsNullOrEmpty(cardType))
            {
                string BankDetails = GetbankDetail("q21312" , cardType);
                Context context = new Context();
                context.SetpayemntStrategy(new PaymentModeFactory().CreateStrategy(cardType));
                bool IsPayemntSuccessful = context.ProcessPayment(BankDetails);
                if (IsPayemntSuccessful)
                {
                    return RedirectToAction("PayemntSuccess", new RouteValueDictionary(new
                    {
                        Controller = "Home",
                        Action = "PayemntSuccess",
                        Id = cardType == "Credit Card" ? "Credit Card" : "Debit Card"
                    })); 
                }


                //if (cardType == "Credit Card")
                //{
                //    return RedirectToAction("PayemntSuccess", new RouteValueDictionary(new { Controller = "Home", Action = "PayemntSuccess", Id = "Credit Card" }));
                //}
                //else
                //{
                //    return RedirectToAction("PayemntSuccess", new RouteValueDictionary(new { Controller = "Home", Action = "PayemntSuccess", Id = "Debit Card" }));
                //}
            }
            return View();
        }
        private string GetbankDetail(string cusId , string Mode)
        {
            return "ICICI";
        }
        public IActionResult PayemntSuccess(string Id)
        {
            ViewBag.Parem = Id;
            return View();
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
