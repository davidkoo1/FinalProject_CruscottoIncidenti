namespace Domain.Entities.HelpDesk
{
    public class Incident
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string RequestNr { get; set; }
        public string Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string ApplicationType { get; set; }
        public string Urgency { get; set; }
        public string SubCause { get; set; }
        public string ProblemSummary { get; set; }
        public string ProblemDescription { get; set; }
        public int IncidentTypeId { get; set; }

        public IncidentType IncidentType { get; set; }
    }
}
