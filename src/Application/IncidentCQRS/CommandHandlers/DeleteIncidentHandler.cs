using Application.Common.Interfaces;
using Application.IncidentCQRS.Commands;
using MediatR;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class DeleteIncidentHandler : IRequestHandler<DeleteIncident, bool>
    {
        private readonly IIncidentRepository _incidentRepository;

        public DeleteIncidentHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<bool> Handle(DeleteIncident request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.DeleteIncident(request.Id);
        }
    }
}
