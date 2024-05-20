using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolunteerWeb.Data;
using VolunteerWeb.Models;
using Microsoft.AspNetCore.Authorization;
namespace VolunteerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VolunteerContext _context;

        public HomeController(ILogger<HomeController> logger, VolunteerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }


        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult News()
        {
            var news = _context.News.ToList();
            return View(news);
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult AskingHelp()
        {
            // Отримання даних з бази даних
            var peoples = _context.People.ToList();
            var helpRequests = _context.HelpRequests.ToList();

            var model = new AskingHelpViewModel
            {
                Peoples = peoples,
                HelpRequests = helpRequests
            };

            // Передача даних у представлення
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
