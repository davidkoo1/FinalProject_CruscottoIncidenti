using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class IncidentTypeConfiguration : IEntityTypeConfiguration<IncidentType>
    {
        public void Configure(EntityTypeBuilder<IncidentType> builder)
        {
            builder.HasKey(x => x.Id)
                 .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(t => t.Ambit).WithMany().HasForeignKey(t => t.AmbitId);
        }
    }
}

