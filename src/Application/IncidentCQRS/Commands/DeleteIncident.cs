using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IncidentCQRS.Commands
{
    public class DeleteIncident : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
