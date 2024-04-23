using Domain.Entities.HelpDesk;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class ScenaryConfig : IEntityTypeConfiguration<Scenary>
    {
        public void Configure(EntityTypeBuilder<Scenary> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.HasData(DbSeed.ScenaryA1, DbSeed.ScenaryA2, DbSeed.ScenaryA3);

        }
    }
}
