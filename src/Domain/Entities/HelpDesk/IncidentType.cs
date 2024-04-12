namespace Domain.Entities.HelpDesk
{
    public class IncidentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmbitId { get; set; }

        public IncidentAmbit Ambit { get; set; }
    }
}
