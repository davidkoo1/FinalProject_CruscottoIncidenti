using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using MediatR;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            //var users = request;
            return await _userRepository.GetAll();
        }
    }
}
