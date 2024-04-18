using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetIncidentByIdHandler : IRequestHandler<GetIncidentById, IncidentDetailDto>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetIncidentByIdHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IncidentDetailDto> Handle(GetIncidentById request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetIncidentById(request.Id);
        }
    }
}
