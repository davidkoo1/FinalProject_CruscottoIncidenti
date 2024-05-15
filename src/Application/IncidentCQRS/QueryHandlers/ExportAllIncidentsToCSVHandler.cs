using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IncidentCQRS.QueryHandlers
{
    public class ExportAllIncidentsToCSVHandler : IRequestHandler<ExportAllIncidentsToCSV, byte[]>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ExportAllIncidentsToCSVHandler(IApplicationDbContext dbContext, IMapper mapper, IFileService fileService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(ExportAllIncidentsToCSV request, CancellationToken cancellationToken)
        {
            var incidents = _mapper.Map<IEnumerable<IncidentDetailDto>>(
            await _dbContext.Incidents
            .Where(x => !x.IsDeleted)
            .Include(x => x.Ambit)
            .Include(x => x.Origin)
            .Include(x => x.IncidentType)
            .Include(x => x.Scenary)
            .Include(x => x.Threat).ToListAsync(cancellationToken));
            return await _fileService.CreateCsvFileAsync(incidents);
        }
    }
}
