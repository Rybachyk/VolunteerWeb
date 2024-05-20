using Microsoft.AspNetCore.Mvc;
using VolunteerWeb.Data;
using VolunteerWeb.Models.DataBaseModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace VolunteerWeb.Controllers
{
    public class AskingHelpController : Controller
    {
        private readonly VolunteerContext _context;

        public AskingHelpController(VolunteerContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AskingHelp()
        {

            var model = new AskingHelpViewModel
            {
                Peoples = _context.People.ToList(),
                HelpRequests = _context.HelpRequests.ToList()
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePeople(Guid peopleId)
        {
            var people = _context.People.Find(peopleId);
            if (people != null)
            {
                var peopleGuid = new Guid(peopleId.ToString()); // Перетворення int на Guid
                var helpRequests = _context.HelpRequests.Where(hr => hr.PeopleId == peopleGuid);
                _context.People.Remove(people);
                _context.HelpRequests.RemoveRange(helpRequests);
                _context.SaveChanges();
            }
            return RedirectToAction("AskingHelp", "Home");
        }
    }
}