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
        public string Solution { get; set; }

        public bool IsDeleted { get; set; }

        public int? IncidentTypeId { get; set; }
        public int? AmbitId { get; set; }
        public int? OriginId { get; set; }
        public string ThirdParty { get; set; }
        public int ScenaryId { get; set; }
        public int ThreatId { get; set; }
        public IncidentType IncidentType { get; set; }
        public IncidentOrigin Origin { get; set; }
        public IncidentAmbit Ambit { get; set; }
        public Scenary Scenary { get; set; }
        public Threat Threat { get; set; }
    }
}
