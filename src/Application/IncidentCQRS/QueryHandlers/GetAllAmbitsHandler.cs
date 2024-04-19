using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllAmbitsHandler : IRequestHandler<GetAllAmbits, IEnumerable<SimpleDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllAmbitsHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllAmbits request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetAllAmbitsByOrigin(request.OriginId);
        }
    }
}
