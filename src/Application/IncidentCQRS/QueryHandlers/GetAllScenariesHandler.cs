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
    public class GetAllScenariesHandler : IRequestHandler<GetAllScenaries, IEnumerable<SimpleDto>>
    {
        private readonly IIncidentRepository _incidentRepository;

        public GetAllScenariesHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllScenaries request, CancellationToken cancellationToken)
        {
            return await _incidentRepository.GetAllScenaries();
        }
    }
}
