using Microsoft.AspNetCore.Mvc;
using MVCCore_Day1.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace MVCCore_Day1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // ---->
        // if the input paramater is id
        // can send on the url by one of
        // 1- /Controller/Action/5
        // 2- /Controller/Action?id=5
        public IActionResult Mix(int id)
        {
            if (id % 2 == 0)
                return Content($"Even Number -> {id}");
            else
                return View("OddView");
        }
    }
}