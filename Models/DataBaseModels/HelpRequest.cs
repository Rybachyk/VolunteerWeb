namespace VolunteerWeb.Models.DataBaseModels
{
    public class HelpRequest
    {
        public Guid Id { get; set; }
        public Guid PeopleId { get; set; }
        public string ProblemDescription { get; set; }
        public People People { get; set; }
    }

}
