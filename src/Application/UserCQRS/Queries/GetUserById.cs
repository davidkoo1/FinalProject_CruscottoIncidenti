using Application.DTO;
using MediatR;

namespace Application.UserCQRS.Queries
{
    public class GetUserById : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
