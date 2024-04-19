using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllIncidentTypesHandler : IRequestHandler<GetAllIncidentTypes, IEnumerable<SimpleDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllIncidentTypesHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllIncidentTypes request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetAllTypesByAmbit(request.AmbitId);
        }
    }
}
