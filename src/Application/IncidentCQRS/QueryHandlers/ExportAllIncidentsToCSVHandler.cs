using Application.Common.Interfaces;
using Application.IncidentCQRS.Queries;
using MediatR;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class ExportAllIncidentsToCSVHandler : IRequestHandler<ExportAllIncidentsToCSV, byte[]>
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IFileService _fileService;

        public ExportAllIncidentsToCSVHandler(IIncidentRepository incidentRepository, IFileService fileService)
        {
            _incidentRepository = incidentRepository;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(ExportAllIncidentsToCSV request, CancellationToken cancellationToken)
        {
            var incidents = await _incidentRepository.GetAllIncidentsForCVS();
            return await _fileService.CreateCsvFileAsync(incidents);
        }
    }
}
