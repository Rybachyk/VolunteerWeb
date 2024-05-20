using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolunteerWeb._DataAccess;
using VolunteerWeb.Models;

namespace VolunteerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VolonteerContext _context;

        public HomeController(ILogger<HomeController> logger, VolonteerContext context)
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

        public IActionResult News()
        {
            var news = _context.News.ToList();
            Console.WriteLine("Список новин:");
            foreach (var item in news)
            {
                Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Content: {item.Content}, PhotoPath: {item.PhotoPath}");
            }
            return View(news);
        }

        public IActionResult Support()
        {
            var donations = _context.Donations.ToList();
            return View(donations);
        }
        public IActionResult AskingHelp()
        {
            // Отримання даних з бази даних
            var users = _context.Users.ToList();
            var helpRequests = _context.HelpRequests.ToList();

            var model = new AskingHelpViewModel
            {
                Users = users,
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
