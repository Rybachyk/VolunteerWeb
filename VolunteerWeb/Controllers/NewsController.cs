using Microsoft.AspNetCore.Mvc;
using VolunteerWeb._DataAccess;
using VolunteerWeb.Models.DataBaseModels;
using System.Linq;

namespace VolunteerWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly VolonteerContext _context;

        public NewsController(VolonteerContext context)
        {
            _context = context;
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

        [HttpPost]
        public IActionResult AddNews(News news)
        {
            if (ModelState.IsValid)
            {
                _context.News.Add(news);
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult DeleteNews(int id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
