﻿using MediatR;

namespace Application.IncidentCQRS.Queries
{
    public class ExportAllIncidentsToCSV : IRequest<byte[]>
    {
    }
}
