using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllInicdents : IRequest<IEnumerable<IncidentDto>>
    {
        public int Id { get; set; }
        public string RequestNr { get; set; }
        public string? Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string? Urgency { get; set; }
    }
}
