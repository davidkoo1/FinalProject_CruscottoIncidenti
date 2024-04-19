using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllOriginsHandler : IRequestHandler<GetAllOrigins, IEnumerable<SimpleDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllOriginsHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllOrigins request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetAllOrigins();
        }
    }

}
