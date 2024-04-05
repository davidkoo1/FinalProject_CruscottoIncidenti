using Application.Common.Interfaces;
using Application.RoleCQRS.Queries;
using Domain.Entities;
using MediatR;

namespace Application.RoleCQRS.QueryHandlers
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRoles, IEnumerable<Role>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllRolesHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetRolesAsync();
        }
    }
}
