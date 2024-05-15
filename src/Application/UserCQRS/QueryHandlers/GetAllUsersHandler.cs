using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _dbContext.Users
            .Search(request.Parameters)
            .OrderBy(request.Parameters)
            .Page(request.Parameters)
            .ToListAsync(cancellationToken));
        }
    }
}
