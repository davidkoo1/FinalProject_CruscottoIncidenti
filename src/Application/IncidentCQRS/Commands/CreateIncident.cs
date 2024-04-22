using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Commands
{
    public class CreateIncident : IRequest<bool>
    {
        public UpsertIncidentDto UpsertIncidentDto { get; set; }
    }
}
