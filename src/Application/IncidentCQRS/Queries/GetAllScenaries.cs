using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllScenaries : IRequest<IEnumerable<SimpleDto>>
    {

    }
}
