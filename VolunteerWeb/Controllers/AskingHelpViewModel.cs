using VolunteerWeb.Models.DataBaseModels;

namespace VolunteerWeb.Controllers
{
    public class AskingHelpViewModel
    {
        public List<User> Users { get; set; }
        public List<HelpRequest> HelpRequests { get; set; }
    }
}