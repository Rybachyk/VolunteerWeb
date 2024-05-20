using VolunteerWeb.Models.DataBaseModels;

namespace VolunteerWeb.Controllers
{
    public class AskingHelpViewModel
    {
        public List<People>Peoples { get; set; }
        public List<HelpRequest> HelpRequests { get; set; }
    }
}