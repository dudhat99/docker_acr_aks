using System.Diagnostics;
using DockerAKSWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerAKSWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            string appName = _config["AppName"] ?? "";
            ViewBag.appName = appName;
            string appLogLevel = _config["MyConfig:LogLevel"] ?? "";
            ViewBag.appLogLevel = appLogLevel;
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
