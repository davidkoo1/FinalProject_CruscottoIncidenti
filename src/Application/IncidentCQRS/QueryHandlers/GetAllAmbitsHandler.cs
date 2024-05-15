using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllAmbitsHandler : IRequestHandler<GetAllAmbits, IEnumerable<SimpleDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllAmbitsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllAmbits request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Ambits
             .Include(x => x.OriginsToAmbits)
             .Where(x => x.OriginsToAmbits.Any(a => a.AmbitId == x.Id && a.OriginId == request.OriginId)).ToListAsync(cancellationToken));
        }
    }
}
