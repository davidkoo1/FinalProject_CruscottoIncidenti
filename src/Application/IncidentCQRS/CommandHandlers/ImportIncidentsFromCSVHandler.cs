using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Commands;
using Domain.Entities.HelpDesk;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.CommandHandlers
{
    public class ImportIncidentsFromCSVHandler : IRequestHandler<ImportIncidentsFromCSV, bool>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImportIncidentsFromCSVHandler(IFileService fileService, IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _fileService = fileService;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(ImportIncidentsFromCSV request, CancellationToken cancellationToken)
        {
            var incidents = await _fileService.ReadCsvFileAsync<IncidentDetailDto>(request.File);

            var existingIncidents = await _dbContext.Incidents.Where(x => !x.IsDeleted).ToListAsync();

            var incidentDtos = incidents
                .Select(record =>
                    new Incident
                    {
                        RequestNr = record.RequestNr,
                        Subsystem = record.Subsystem,
                        CreatedBy = _httpContextAccessor.HttpContext?.User.GetUserId(),
                        Created = DateTime.UtcNow,
                        OpenDate = record.OpenDate,
                        CloseDate = record.CloseDate,
                        Type = record.Type,
                        ApplicationType = record.ApplicationType,
                        Urgency = record.Urgency,
                        SubCause = record.SubCause,
                        ProblemSummary = record.ProblemSummary,
                        ProblemDescription = record.ProblemDescription,
                        Solution = record.Solution,
                        OriginId = _dbContext.Origins.FirstOrDefault(x => x.Name.Equals(record.Origin)).Id,
                        AmbitId = _dbContext.Ambits.FirstOrDefault(x => x.Name.Equals(record.Ambit)).Id,
                        IncidentTypeId = _dbContext.IncidentTypes.FirstOrDefault(x => x.Name.Equals(record.IncidentType)).Id,
                        ScenaryId = _dbContext.Scenaries.FirstOrDefault(x => x.Name.Equals(record.Scenary)).Id,
                        ThreatId = _dbContext.Threats.FirstOrDefault(x => x.Name.Equals(record.Threat)).Id
                    }).Where(newIncident => !existingIncidents.Any(existing => existing.RequestNr == newIncident.RequestNr))
                .ToList();

            _dbContext.Incidents.AddRange(incidentDtos);

            return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
