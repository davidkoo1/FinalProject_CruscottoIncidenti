using MediatR;

namespace Application.UserCQRS.Commands
{
    public class DeleteUser : IRequest<bool>
    {
        public int Id { get; set; }

    }
}
