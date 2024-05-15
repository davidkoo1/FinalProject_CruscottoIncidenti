using Domain.Entities.HelpDesk;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Incident> Incidents { get; set; }
        DbSet<IncidentType> IncidentTypes { get; set; }
        DbSet<IncidentAmbit> Ambits { get; set; }
        DbSet<IncidentOrigin> Origins { get; set; }
        DbSet<Scenary> Scenaries { get; set; }
        DbSet<Threat> Threats { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
