using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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

        }
    }
}
