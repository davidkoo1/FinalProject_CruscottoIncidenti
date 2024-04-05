using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using MediatR;

namespace Application.UserCQRS.QueryHandlers
{
    public class UpsertUserHandler : IRequestHandler<GetUserForUpsert, UpsertUserDto>
    {
        private readonly IUserRepository _userRepository;

        public UpsertUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpsertUserDto> Handle(GetUserForUpsert request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserForUpsertById(request.Id);
        }
    }
}
