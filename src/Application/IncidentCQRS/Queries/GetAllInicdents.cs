using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllInicdents : IRequest<IEnumerable<IncidentDto>>
    {

    }
}
