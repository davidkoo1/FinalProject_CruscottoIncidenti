using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllAmbits : IRequest<IEnumerable<SimpleDto>>
    {
        public int OriginId { get; set; }
    }
}
