using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
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
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ApplicationType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Urgency)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.SubCause)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ProblemSummary)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ProblemDescription)
                .HasMaxLength(350)
                .IsRequired();

            builder.HasOne(i => i.IncidentType).WithMany().HasForeignKey(i => i.IncidentTypeId);

        }
    }
}
