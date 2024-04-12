namespace Domain.Entities.HelpDesk
{
    public class IncidentAmbit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }

        public IncidentOrigin Origin { get; set; }
    }
}
