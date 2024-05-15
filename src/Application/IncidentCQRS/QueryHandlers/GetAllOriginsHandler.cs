using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class GetAllOriginsHandler : IRequestHandler<GetAllOrigins, IEnumerable<SimpleDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOriginsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SimpleDto>> Handle(GetAllOrigins request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Origins.ToListAsync(cancellationToken));
        }
    }

}
