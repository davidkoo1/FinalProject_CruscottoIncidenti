using Application.Common.Interfaces;
using Application.RoleCQRS.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.RoleCQRS.QueryHandlers
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRoles, IEnumerable<Role>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllRolesHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            return await _dbContext.Roles.ToListAsync(cancellationToken);
        }
    }
}
