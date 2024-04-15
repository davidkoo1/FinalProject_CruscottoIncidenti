namespace Domain.Entities.HelpDesk
{
    public class OriginsToAmbit
    {
        public int OriginId { get; set; }
        public int AmbitId { get; set; }

        public IncidentOrigin Origin { get; set; }
        public IncidentAmbit Ambit { get; set; }
    }
}
