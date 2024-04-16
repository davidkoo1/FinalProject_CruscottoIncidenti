using Application.DTO;

namespace Application.Common.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<IncidentDto>> GetAllIncidents();

        Task<IncidentDto> GetIncidentById(int Id);
    }
}
