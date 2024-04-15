namespace Domain.Entities.HelpDesk
{
    public class Threat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }
    }
}
