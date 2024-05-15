using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllIncidentTypesHandler : IRequestHandler<GetAllIncidentTypes, IEnumerable<SimpleDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllIncidentTypesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllIncidentTypes request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.IncidentTypes
                .Include(x => x.AmbitsToTypes)
                .Where(x => x.AmbitsToTypes.Any(a => a.TypeId == x.Id && a.AmbitId == request.AmbitId))
                .ToListAsync(cancellationToken));
        }
    }
}
