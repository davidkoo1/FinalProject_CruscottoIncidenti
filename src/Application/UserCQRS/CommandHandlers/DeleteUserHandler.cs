using Application.Common.Interfaces;
using Application.UserCQRS.Commands;
using Domain.Entities;
using MediatR;

namespace Application.UserCQRS.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteUserHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users
            .FirstOrDefault(p => p.Id == request.Id);

            if (user is null) return false;

            _dbContext.Users.Remove(user);

            return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
