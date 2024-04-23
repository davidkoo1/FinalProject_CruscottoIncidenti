using Application.DTO;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetIncidentForUpsert : IRequest<UpsertIncidentDto>
    {
        public int Id { get; set; }
    }
}
