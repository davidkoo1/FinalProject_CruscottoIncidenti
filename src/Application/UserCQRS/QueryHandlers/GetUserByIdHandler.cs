using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, UserDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _dbContext.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));

        }
    }
}
