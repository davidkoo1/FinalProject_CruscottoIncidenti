using Application.DTO;
using MediatR;

namespace Application.UserCQRS.Commands
{
    public class UpsertUser : IRequest<bool>
    {
        public UpsertUserDto UpsertUserDto { get; set; }
    }
}
