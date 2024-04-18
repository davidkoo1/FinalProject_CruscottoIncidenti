using Application.DTO;

namespace Application.Common.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<IncidentDto>> GetAllIncidents();

        Task<IncidentDetailDto> GetIncidentById(int Id);

        Task<bool> DeleteIncident(int incidentId);
        Task<bool> Save();
    }
}
