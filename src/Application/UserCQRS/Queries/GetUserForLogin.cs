using Domain.Entities;
using MediatR;

namespace Application.UserCQRS.Queries
{
    public class GetUserForLogin : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
