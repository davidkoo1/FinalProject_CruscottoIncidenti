using Domain.Common;

namespace Domain.Entities.HelpDesk
{
    public class Scenary : Entity<int>
    {
        public string Name { get; set; }
        public List<Incident> Incidents { get; set; }

    }
}
