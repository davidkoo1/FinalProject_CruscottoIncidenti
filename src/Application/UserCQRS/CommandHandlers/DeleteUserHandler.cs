using Application.Common.Interfaces;
using Application.UserCQRS.Commands;
using MediatR;

namespace Application.UserCQRS.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUser(request.Id);
        }
    }
}
