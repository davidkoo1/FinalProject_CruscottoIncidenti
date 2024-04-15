namespace Domain.Entities.HelpDesk
{
    public class AmbitsToTypes
    {
        public int AmbitId { get; set; }
        public int TypeId { get; set; }

        public IncidentAmbit Ambit { get; set; }
        public IncidentType Type { get; set; }
    }
}
