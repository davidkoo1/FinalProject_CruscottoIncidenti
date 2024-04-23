using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class UpsertIncidentHandler : IRequestHandler<GetIncidentForUpsert, UpsertIncidentDto>
    {
        private readonly IIncidentRepository _incidentRepository;

        public UpsertIncidentHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<UpsertIncidentDto> Handle(GetIncidentForUpsert request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetIncidentForUpsertById(request.Id);
        }
    }
}
