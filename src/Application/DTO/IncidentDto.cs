using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public string RequestNr { get; set; }
        public string? Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string? Urgency { get; set; }
    }
}
