using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllScenariesHandler : IRequestHandler<GetAllScenaries, IEnumerable<SimpleDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllScenariesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllScenaries request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Scenaries.ToListAsync(cancellationToken));
        }
    }
}
