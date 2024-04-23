using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllOrigins : IRequest<IEnumerable<SimpleDto>>
    {

    }
}
