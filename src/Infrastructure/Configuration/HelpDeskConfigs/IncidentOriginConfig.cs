using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class IncidentOriginConfig : IEntityTypeConfiguration<IncidentOrigin>
    {
        public void Configure(EntityTypeBuilder<IncidentOrigin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.HasData(DbSeed.Aplication, DbSeed.External, DbSeed.Infrastructure);
        }
    }
}
