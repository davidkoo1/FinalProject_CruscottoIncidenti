namespace Domain.Entities.HelpDesk
{
    public class IncidentOrigin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OriginsToAmbit> OriginsToAmbits { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
