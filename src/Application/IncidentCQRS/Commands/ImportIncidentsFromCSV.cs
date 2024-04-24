using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.IncidentCQRS.Commands
{
    public class ImportIncidentsFromCSV : IRequest<bool>
    {
        public IFormFile File { get; set; }
    }
}
