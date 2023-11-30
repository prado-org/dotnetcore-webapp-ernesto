using Microsoft.AspNetCore.Mvc;
using MyFirstProject.WebApp.Models;
using System.Diagnostics;

namespace MyFirstProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // outro teste
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.VersionInfoNumber = _configuration.GetSection("VersionInfo:Number").Value;
            ViewBag.VersionInfoDate = _configuration.GetSection("VersionInfo:Date").Value;
            var connAdo = "payoihpodpcqhn6xhaxzau3w77fgvrgtk26qgrigitpbl2rnsr4q";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var myInfo = "109.326.110-28";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
