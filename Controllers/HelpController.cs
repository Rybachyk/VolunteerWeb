using Microsoft.AspNetCore.Mvc;
using VolunteerWeb.Data;
using VolunteerWeb.Models.DataBaseModels;

namespace VolunteerWeb.Controllers
{
    public class HelpController : Controller
    {
        private readonly VolunteerContext _context;

        public HelpController(VolunteerContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult SubmitHelpRequest(string name, string surname, string phone, string problem_description)
        {
            // Створюємо новий користувач
            var people = new People
            {
                FirstName = name,
                LastName = surname,
                Phone = phone
            };

            // Додаємо користувача до контексту бази даних
            _context.People.Add(people);

            // Зберігаємо зміни в базі даних
            _context.SaveChanges();

            // Створюємо новий запит на допомогу
            var helpRequest = new HelpRequest
            {
                PeopleId = people.Id,
                ProblemDescription = problem_description
            };

            // Додаємо запит на допомогу до контексту бази даних
            _context.HelpRequests.Add(helpRequest);

            // Зберігаємо зміни в базі даних
            _context.SaveChanges();

            // Повертаємо користувача на домашню сторінку або на іншу сторінку за вашим вибором
            return RedirectToAction("Index", "Home");
        }
    }
}
