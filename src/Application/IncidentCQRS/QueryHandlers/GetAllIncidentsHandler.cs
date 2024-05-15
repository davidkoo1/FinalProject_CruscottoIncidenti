using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Extensions;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllIncidentsHandler : IRequestHandler<GetAllInicdents, IEnumerable<IncidentDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllIncidentsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IncidentDto>> Handle(GetAllInicdents request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<IncidentDto>>(
            await _dbContext.Incidents.Where(x => !x.IsDeleted)
            .Search(request.Parameters)
            .OrderBy(request.Parameters)
            .Page(request.Parameters)
            .ToListAsync(cancellationToken));
        }
    }
}
