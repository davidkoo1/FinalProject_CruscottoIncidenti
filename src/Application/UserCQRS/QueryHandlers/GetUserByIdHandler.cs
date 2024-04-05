using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using MediatR;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.Id);
        }
    }
}
