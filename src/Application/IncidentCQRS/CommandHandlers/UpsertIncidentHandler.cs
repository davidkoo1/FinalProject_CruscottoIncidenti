using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.IncidentCQRS.Commands;
using AutoMapper;
using Domain.Entities.HelpDesk;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class UpsertIncidentHandler : IRequestHandler<UpsertIncident, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpsertIncidentHandler(IApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(UpsertIncident request, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Incidents.AnyAsync(x =>
               x.RequestNr == request.UpsertIncidentDto.RequestNr &&
               x.Id != request.UpsertIncidentDto.Id &&
               !x.IsDeleted);

            if (request.UpsertIncidentDto == null || existing)
            {
                return false;
            }

            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var incident = _mapper.Map<Incident>(request.UpsertIncidentDto);
            if (request.UpsertIncidentDto.Id == 0)
            {


                incident.OpenDate = DateTime.UtcNow;
                incident.CreatedBy = currentUser;

                await _dbContext.Incidents.AddAsync(incident);
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
            }
            else
            {
                incident.LastModified = DateTime.UtcNow;
                incident.LastModifiedBy = currentUser;
                _dbContext.Incidents.Update(incident);
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
            }
        }
    }
}
