using Domain.Common;

namespace Domain.Entities.HelpDesk
{
    public class Threat : Entity<int>
    {
        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }
    }
}
