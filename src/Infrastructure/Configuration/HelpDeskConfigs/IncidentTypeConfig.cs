using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class IncidentTypeConfig : IEntityTypeConfiguration<IncidentType>
    {
        public void Configure(EntityTypeBuilder<IncidentType> builder)
        {

            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(35)
                .IsRequired();
        }
    }
}
