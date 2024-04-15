namespace Domain.Entities.HelpDesk
{
    public class IncidentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }
        public List<AmbitsToTypes> AmbitsToTypes { get; set; }
    }
}
