using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestNr)
                .HasMaxLength(17)
                .IsRequired();

            builder.HasIndex(x => x.RequestNr)
                .IsUnique();

            builder.Property(x => x.Subsystem)
                .HasMaxLength(2);

            builder.Property(x => x.Type)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.ApplicationType)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.Urgency)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.SubCause)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.ProblemSummary)
                .HasMaxLength(255);

            builder.Property(x => x.ProblemDescription)
                .HasMaxLength(500);

            builder.Property(x => x.Solution)
                .HasMaxLength(250);

            builder.Property(x => x.ThirdParty)
                .HasMaxLength(35);


            builder.Property(x => x.OriginId)
                .IsRequired(false);

            builder.Property(x => x.AmbitId)
                .IsRequired(false);

            builder.Property(x => x.IncidentTypeId)
                .IsRequired(false);


            builder.HasOne(x => x.Scenary)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.ScenaryId);

            builder.HasOne(x => x.Threat)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.ThreatId);

            builder.HasOne(x => x.Origin)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.OriginId);

            builder.HasOne(x => x.Ambit)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.AmbitId);

            builder.HasOne(x => x.IncidentType)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.IncidentTypeId);


            builder.HasData(DbSeed.Incident1);
        }
    }
}
