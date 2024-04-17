using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

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
