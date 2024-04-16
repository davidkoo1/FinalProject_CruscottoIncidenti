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

        public async Task<IEnumerable<IncidentDto>> GetAllIncidents() => _mapper.Map<IEnumerable<IncidentDto>>(await _dbContext.Incidents.ToListAsync());

        public async Task<IncidentDto> GetIncidentById(int Id) => _mapper.Map<IncidentDto>(await _dbContext.Incidents.FirstOrDefaultAsync(x => x.Id == Id));
    }
}
