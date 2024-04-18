using Application.Common.Interfaces;
using Application.DTO;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IncidentRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<IncidentDetailDto> GetIncidentById(int Id) => _mapper.Map<IncidentDetailDto>(await _dbContext.Incidents
            .Include(x => x.Ambit)
            .Include(x => x.Origin)
            .Include(x => x.IncidentType)
            .Include(x => x.Scenary)
            .Include(x => x.Threat)
            .FirstOrDefaultAsync(x => x.Id == Id));

        public async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0 ? true : false;
    }
}
