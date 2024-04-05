using Domain.Entities;
using MediatR;

namespace Application.RoleCQRS.Queries
{
    public class GetAllRoles : IRequest<IEnumerable<Role>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
