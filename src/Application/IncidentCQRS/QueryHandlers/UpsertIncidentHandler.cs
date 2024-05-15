using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class UpsertIncidentHandler : IRequestHandler<GetIncidentForUpsert, UpsertIncidentDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpsertIncidentHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UpsertIncidentDto> Handle(GetIncidentForUpsert request, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Incidents.AnyAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (existing)
            {
                return _mapper.Map<UpsertIncidentDto>(await _dbContext.Incidents
                    .Include(x => x.Ambit)
                    .Include(x => x.Origin)
                    .Include(x => x.IncidentType)
                    .Include(x => x.Scenary)
                    .Include(x => x.Threat)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));
            }
            return new UpsertIncidentDto();
        }
    }
}
