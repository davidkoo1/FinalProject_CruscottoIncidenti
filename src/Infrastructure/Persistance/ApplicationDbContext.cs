using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<IncidentAmbit> Ambits { get; set; }
        public DbSet<IncidentOrigin> Origins { get; set; }
        public DbSet<AmbitsToTypes> AmbitsToTypes { get; set; }
        public DbSet<OriginsToAmbit> OriginsToAmbit { get; set; }
        public DbSet<Scenary> Scenaries { get; set; }
        public DbSet<Threat> Threats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) => await base.SaveChangesAsync(cancellationToken);
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
