using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllThreats : IRequest<IEnumerable<SimpleDto>>
    {

    }
}
