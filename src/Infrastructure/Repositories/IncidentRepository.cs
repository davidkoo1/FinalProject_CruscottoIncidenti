using Application.Common.Interfaces;
using Application.DTO;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Domain.Entities.HelpDesk;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IncidentRepository(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DeleteIncident(int incidentId)
        {
            var incident = _dbContext.Incidents
             .FirstOrDefault(p => p.Id == incidentId);

            if (incident is null) return false;

            incident.IsDeleted = true;
            _dbContext.Incidents.Update(incident);
            return await Save();
        }

        public async Task<IEnumerable<IncidentDto>> GetAllIncidents() => _mapper.Map<IEnumerable<IncidentDto>>(await _dbContext.Incidents.Where(x => !x.IsDeleted).ToListAsync());

        public async Task<IEnumerable<SimpleDto>> GetAllScenaries() => _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Scenaries.ToListAsync());
        public async Task<IEnumerable<SimpleDto>> GetAllThreats() => _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Threats.ToListAsync());
        public async Task<IEnumerable<SimpleDto>> GetAllOrigins() => _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Origins.ToListAsync());
        public async Task<IEnumerable<SimpleDto>> GetAllAmbitsByOrigin(int originId) => _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.Ambits
            .Include(x => x.OriginsToAmbits)
            .Where(x => x.OriginsToAmbits.Any(a => a.AmbitId == x.Id && a.OriginId == originId)).ToListAsync());
        public async Task<IEnumerable<SimpleDto>> GetAllTypesByAmbit(int ambitId) => _mapper.Map<IEnumerable<SimpleDto>>(await _dbContext.IncidentTypes
                .Include(x => x.AmbitsToTypes)
                .Where(x => x.AmbitsToTypes.Any(a => a.TypeId == x.Id && a.AmbitId == ambitId)).ToListAsync());
        public async Task<IncidentDetailDto> GetIncidentById(int Id) => _mapper.Map<IncidentDetailDto>(await _dbContext.Incidents
            .Include(x => x.Ambit)
            .Include(x => x.Origin)
            .Include(x => x.IncidentType)
            .Include(x => x.Scenary)
            .Include(x => x.Threat)
            .FirstOrDefaultAsync(x => x.Id == Id));

        public async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0 ? true : false;

        public async Task<bool> UpsertIncident(UpsertIncidentDto incidentToUpsert)
        {
            var existing = await _dbContext.Incidents.AnyAsync(x => x.RequestNr == incidentToUpsert.RequestNr && x.Id != incidentToUpsert.Id);
            if (incidentToUpsert == null || existing)
            {
                return false;
            }
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var incident = _mapper.Map<Incident>(incidentToUpsert);
            if (incidentToUpsert.Id == 0)
            {
                

                incident.OpenDate = DateTime.UtcNow;
                incident.CreatedBy = currentUser;

                await _dbContext.Incidents.AddAsync(incident);
                return await Save();
            }
            else
            {
                incident.LastModified = DateTime.UtcNow;
                incident.LastModifiedBy = currentUser;
                _dbContext.Update(incident);
                return await Save();
            }
        }

        public async Task<UpsertIncidentDto> GetIncidentForUpsertById(int incidentId)
        {
            var existing = await _dbContext.Incidents.AnyAsync(x => x.Id == incidentId);
            if (existing)
            {
                return _mapper.Map<UpsertIncidentDto>(await _dbContext.Incidents
                    .Include(x => x.Ambit)
                    .Include(x => x.Origin)
                    .Include(x => x.IncidentType)
                    .Include(x => x.Scenary)
                    .Include(x => x.Threat)
                    .FirstOrDefaultAsync(x => x.Id == incidentId));
            }
            return new UpsertIncidentDto();
        }
    }
}
