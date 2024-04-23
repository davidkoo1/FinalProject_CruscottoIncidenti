using Domain.Entities.HelpDesk;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasData(DbSeed.ThreatAA1, DbSeed.ThreatAA2, DbSeed.ThreatAA3);

        }
    }
}
