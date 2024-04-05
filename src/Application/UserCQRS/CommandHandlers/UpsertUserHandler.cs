using Application.Common.Interfaces;
using Application.UserCQRS.Commands;
using MediatR;

namespace Application.UserCQRS.CommandHandlers
{
    public class UpsertUserHandler : IRequestHandler<UpsertUser, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpsertUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpsertUser request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpsertUser(request.UpsertUserDto);
        }
    }
}
