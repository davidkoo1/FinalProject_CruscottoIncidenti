using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IncidentCQRS.Queries
{
    public class GetIncidentForUpsert : IRequest<UpsertIncidentDto>
    {
        public int Id { get; set; }
    }
}
