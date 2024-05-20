using Microsoft.AspNetCore.Mvc;
using VolunteerWeb._DataAccess;
using VolunteerWeb.Models.DataBaseModels;
using System.Linq;

namespace VolunteerWeb.Controllers
{
    public class AskingHelpController : Controller
    {
        private readonly VolonteerContext _context;

        public AskingHelpController(VolonteerContext context)
        {
            _context = context;
        }

        public IActionResult AskingHelp()
        {

            var model = new AskingHelpViewModel
            {
                Users = _context.Users.ToList(),
                HelpRequests = _context.HelpRequests.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                var helpRequests = _context.HelpRequests.Where(hr => hr.UserId == userId);
                _context.Users.Remove(user);
                _context.HelpRequests.RemoveRange(helpRequests);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
