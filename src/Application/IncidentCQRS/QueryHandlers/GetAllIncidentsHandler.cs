using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllIncidentsHandler : IRequestHandler<GetAllInicdents, IEnumerable<IncidentDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllIncidentsHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<IncidentDto>> Handle(GetAllInicdents request, CancellationToken cancellationToken)
        {
            //var users = request;
            return await _incidentRepository.GetAllIncidents();
        }
    }
}
