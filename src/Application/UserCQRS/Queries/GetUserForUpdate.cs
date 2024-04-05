using Application.DTO;
using MediatR;

namespace Application.UserCQRS.Queries
{
    public class GetUserForUpsert : IRequest<UpsertUserDto>
    {
        public int Id { get; set; }
    }
}
