using Application.Common.Interfaces;
using Application.IncidentCQRS.Commands;
using MediatR;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class UpsertIncidentHandler : IRequestHandler<UpsertIncident, bool>
    {
        private readonly IIncidentRepository _incidentRepository;

        public UpsertIncidentHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<bool> Handle(UpsertIncident request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.UpsertIncident(request.UpsertIncidentDto);
        }
    }
}
