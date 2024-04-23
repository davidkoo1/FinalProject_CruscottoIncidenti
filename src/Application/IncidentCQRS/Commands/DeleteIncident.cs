using MediatR;

namespace Application.IncidentCQRS.Commands
{
    public class DeleteIncident : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
