using Domain.Common;

namespace Domain.Entities.HelpDesk
{
    public class IncidentOrigin : Entity<int>
    {
        public string Name { get; set; }

        public List<OriginsToAmbit> OriginsToAmbits { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
