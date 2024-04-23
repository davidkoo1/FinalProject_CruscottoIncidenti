using Application.DTO;
using Application.TableParameters;
using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class GetAllInicdents : IRequest<IEnumerable<IncidentDto>>
    {
        public DataTablesParameters Parameters { get; set; }
        public GetAllInicdents(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
