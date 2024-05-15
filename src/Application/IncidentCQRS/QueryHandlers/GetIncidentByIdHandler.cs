using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetIncidentByIdHandler : IRequestHandler<GetIncidentById, IncidentDetailDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetIncidentByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IncidentDetailDto> Handle(GetIncidentById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IncidentDetailDto>(await _dbContext.Incidents
            .Include(x => x.Ambit)
            .Include(x => x.Origin)
            .Include(x => x.IncidentType)
            .Include(x => x.Scenary)
            .Include(x => x.Threat)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));
        }
    }
}
