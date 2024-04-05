using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using Domain.Entities;
using MediatR;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetUserLoginHandler : IRequestHandler<GetUserForLogin, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserLoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserForLogin request, CancellationToken cancellationToken)
        {
            var login = new LoginDto
            {
                Username = request.Username,
                Password = request.Password
            };
            return await _userRepository.GetUserForLogin(login);
        }
    }
}
