using Domain.Common;

namespace Domain.Entities.HelpDesk
{
    public class IncidentType : Entity<int>
    {
        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }
        public List<AmbitsToTypes> AmbitsToTypes { get; set; }
    }
}
