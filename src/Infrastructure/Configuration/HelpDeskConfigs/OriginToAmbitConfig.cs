using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class OriginToAmbitConfig : IEntityTypeConfiguration<OriginsToAmbit>
    {
        public void Configure(EntityTypeBuilder<OriginsToAmbit> builder)
        {
            builder.HasKey(x => new { x.OriginId, x.AmbitId });

            builder.HasOne(x => x.Origin)
                .WithMany(x => x.OriginsToAmbits)
                .HasForeignKey(x => x.OriginId);

            builder.HasOne(x => x.Ambit)
                .WithMany(x => x.OriginsToAmbits)
                .HasForeignKey(x => x.AmbitId);

            builder.HasData(DbSeed.OriginsToAmbit1, DbSeed.OriginsToAmbit2, DbSeed.OriginsToAmbit3, DbSeed.OriginsToAmbit4, DbSeed.OriginsToAmbit5, DbSeed.OriginsToAmbit6,
                DbSeed.OriginsToAmbit7, DbSeed.OriginsToAmbit8, DbSeed.OriginsToAmbit9, DbSeed.OriginsToAmbit10, DbSeed.OriginsToAmbit11, DbSeed.OriginsToAmbit12,
                DbSeed.OriginsToAmbit13, DbSeed.OriginsToAmbit14, DbSeed.OriginsToAmbit15, DbSeed.OriginsToAmbit16, DbSeed.OriginsToAmbit17, DbSeed.OriginsToAmbit18,
                DbSeed.OriginsToAmbit19, DbSeed.OriginsToAmbit20, DbSeed.OriginsToAmbit21);

        }
    }
}
