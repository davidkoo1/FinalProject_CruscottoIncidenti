using Application.DTO;
using Application.TableParameters;

namespace Application.Common.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<IncidentDetailDto>> GetAllIncidentsForCVS();
        Task<bool> CreateIncidentsFromCVS(IEnumerable<IncidentDetailDto> incidents);
        Task<IEnumerable<IncidentDto>> GetAllIncidents(DataTablesParameters parameters);
        Task<IEnumerable<SimpleDto>> GetAllOrigins();
        Task<IEnumerable<SimpleDto>> GetAllAmbitsByOrigin(int originId);
        Task<IEnumerable<SimpleDto>> GetAllTypesByAmbit(int ambitId);
        Task<IEnumerable<SimpleDto>> GetAllScenaries();
        Task<IEnumerable<SimpleDto>> GetAllThreats();
        Task<IncidentDetailDto> GetIncidentById(int Id);
        Task<UpsertIncidentDto> GetIncidentForUpsertById(int incidentId);
        Task<bool> UpsertIncident(UpsertIncidentDto incidentToUpsert);
        Task<bool> DeleteIncident(int incidentId);
        Task<bool> Save();
    }
}
