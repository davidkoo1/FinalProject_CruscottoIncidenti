using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Commands;
using MediatR;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class ImportIncidentsFromCSVHandler : IRequestHandler<ImportIncidentsFromCSV, bool>
    {
        private readonly IFileService _fileService;
        private readonly IIncidentRepository _incidentRepository;

        public ImportIncidentsFromCSVHandler(IFileService fileService, IIncidentRepository incidentRepository)
        {
            _fileService = fileService;
            _incidentRepository = incidentRepository;
        }

        public async Task<bool> Handle(ImportIncidentsFromCSV request, CancellationToken cancellationToken)
        {
            var incidents = await _fileService.ReadCsvFileAsync<IncidentDetailDto>(request.File);


            return await _incidentRepository.CreateIncidentsFromCVS(incidents);
        }
    }
}
