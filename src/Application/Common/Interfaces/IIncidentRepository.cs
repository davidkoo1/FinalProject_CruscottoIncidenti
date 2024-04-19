using Application.DTO;
using Application.IncidentCQRS.Commands;

namespace Application.Common.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<IncidentDto>> GetAllIncidents();
        Task<IEnumerable<SimpleDto>> GetAllOrigins();
        Task<IEnumerable<SimpleDto>> GetAllAmbitsByOrigin(int originId);
        Task<IEnumerable<SimpleDto>> GetAllTypesByAmbit(int ambitId);
        Task<IEnumerable<SimpleDto>> GetAllScenaries();
        Task<IEnumerable<SimpleDto>> GetAllThreats();
        Task<IncidentDetailDto> GetIncidentById(int Id);
        Task<bool> UpsertIncident(UpsertIncidentDto incidentToUpsert);
        Task<bool> DeleteIncident(int incidentId);
        Task<bool> Save();
    }
}
