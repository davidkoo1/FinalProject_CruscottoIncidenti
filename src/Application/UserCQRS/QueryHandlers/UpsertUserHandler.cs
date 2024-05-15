using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCQRS.QueryHandlers
{
    public class UpsertUserHandler : IRequestHandler<GetUserForUpsert, UpsertUserDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpsertUserHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UpsertUserDto> Handle(GetUserForUpsert request, CancellationToken cancellationToken)
        {
            if (_dbContext.Users.Any(x => x.Id == request.Id))
            {
                return _mapper.Map<UpsertUserDto>(await _dbContext.Users
                            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));
            }
            return new UpsertUserDto();
        }
    }
}
