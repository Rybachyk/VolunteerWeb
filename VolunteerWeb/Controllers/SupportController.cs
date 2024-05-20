using Microsoft.AspNetCore.Mvc;
using VolunteerWeb._DataAccess;
using VolunteerWeb.Models.DataBaseModels;

namespace VolunteerWeb.Controllers
{
    public class SupportController : Controller
    {
        private readonly VolonteerContext _context;

        public SupportController(VolonteerContext context)
        {
            _context = context;
        }

        public IActionResult Support()
        {
            var donations = _context.Donations.ToList();
            return View(donations);
        }

        [HttpPost]
        public IActionResult AddDonation(Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Donations.Add(donation);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteDonation(int id)
        {
            var donation = _context.Donations.Find(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
