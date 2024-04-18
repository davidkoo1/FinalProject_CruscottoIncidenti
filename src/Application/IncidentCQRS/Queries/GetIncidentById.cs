using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetIncidentById : IRequest<IncidentDetailDto>
    {
        public int Id { get; set; }
    }
}
