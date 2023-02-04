using day8solid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace day8solid.Controllers
{

        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            firmDBcontext DB = new firmDBcontext();
            public HomeController(ILogger<HomeController> logger)
            {
                var q = DB.employees.Where(x => x.SSN == 1).SingleOrDefault();
                _logger = logger;
            }

            public IActionResult Index()
            {
                var q = DB.employees.Where(x => x.SSN == 1).SingleOrDefault();
                return RedirectToAction("registration", "account");
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