using Microsoft.AspNetCore.Mvc;
using VolunteerWeb.Data;
using VolunteerWeb.Models.DataBaseModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace VolunteerWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly VolunteerContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewsController(VolunteerContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult News()
        {
            var news = _context.News.ToList();
            return View(news);
        }
        public IActionResult DetailsNews(Guid id)
        {
            var news = _context.News.FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }




        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddNews(News news)
        {
            if (ModelState.IsValid)
            {
                _context.News.Add(news);
                _context.SaveChanges();
            }
            return RedirectToAction("News", "Home");
        }
        


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteNews(Guid id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
            }
            return RedirectToAction("News", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditNews(Guid id)
        {
            var news = _context.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditNews(News news)
        {
            if (ModelState.IsValid)
            {
                _context.News.Update(news);
                _context.SaveChanges();
                return RedirectToAction("News", "Home");
            }
            return View(news);
        }
    }
}
