namespace Domain.Entities.HelpDesk
{
    public class IncidentOrigin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<IncidentAmbit> Ambits { get; set;}
    }
}
