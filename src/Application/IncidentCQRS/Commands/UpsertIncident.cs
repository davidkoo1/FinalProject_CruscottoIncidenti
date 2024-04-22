using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Commands
{
    public class UpsertIncident : IRequest<bool>
    {
        public UpsertIncidentDto UpsertIncidentDto { get; set; }
    }
}
