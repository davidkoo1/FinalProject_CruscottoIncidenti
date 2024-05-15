using Application.Common.Interfaces;
using Application.IncidentCQRS.Commands;
using Domain.Entities.HelpDesk;
using MediatR;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class DeleteIncidentHandler : IRequestHandler<DeleteIncident, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteIncidentHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteIncident request, CancellationToken cancellationToken)
        {
            var incident = _dbContext.Incidents
             .FirstOrDefault(p => p.Id == request.Id);

            if (incident is null) return false;

            incident.IsDeleted = true;
            _dbContext.Incidents.Update(incident);
            return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
