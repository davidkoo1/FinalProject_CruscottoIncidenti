using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class ThreatConfig : IEntityTypeConfiguration<Threat>
    {
        public void Configure(EntityTypeBuilder<Threat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(35)
                .IsRequired();

        }
    }
}
