using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllIncidentTypes : IRequest<IEnumerable<SimpleDto>>
    {
        public int AmbitId { get; set; }
    }
}
