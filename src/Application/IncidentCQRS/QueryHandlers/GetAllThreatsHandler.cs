using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllThreatsHandler : IRequestHandler<GetAllThreats, IEnumerable<SimpleDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllThreatsHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllThreats request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetAllThreats();
        }
    }
}
