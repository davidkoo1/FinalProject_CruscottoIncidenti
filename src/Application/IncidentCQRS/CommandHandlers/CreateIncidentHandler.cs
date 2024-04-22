using Application.Common.Interfaces;
using Application.IncidentCQRS.Commands;
using MediatR;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class CreateIncidentHandler : IRequestHandler<CreateIncident, bool>
    {
        private readonly IIncidentRepository _incidentRepository;

        public CreateIncidentHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<bool> Handle(CreateIncident request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.UpsertIncident(request.UpsertIncidentDto);
        }
    }
}
