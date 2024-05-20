using Microsoft.AspNetCore.Mvc;
using VolunteerWeb._DataAccess;
using VolunteerWeb.Models.DataBaseModels;

namespace VolunteerWeb.Controllers
{
    public class HelpController : Controller
    {
        private readonly VolonteerContext _context;

        public HelpController(VolonteerContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult SubmitHelpRequest(string name, string surname, string phone, string problem_description)
        {
            // Створюємо новий користувач
            var user = new User
            {
                FirstName = name,
                LastName = surname,
                Phone = phone
            };

            // Додаємо користувача до контексту бази даних
            _context.Users.Add(user);

            // Зберігаємо зміни в базі даних
            _context.SaveChanges();

            // Створюємо новий запит на допомогу
            var helpRequest = new HelpRequest
            {
                UserId = user.Id,
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
