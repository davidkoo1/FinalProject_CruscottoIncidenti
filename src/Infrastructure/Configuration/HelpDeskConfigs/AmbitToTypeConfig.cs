using Domain.Entities;
using Domain.Entities.HelpDesk;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class AmbitToTypeConfig : IEntityTypeConfiguration<AmbitsToTypes>
    {
        public void Configure(EntityTypeBuilder<AmbitsToTypes> builder)
        {
            builder.HasNoKey();
            builder.HasKey(x => new { x.AmbitId, x.TypeId });

            builder.HasOne(x => x.Ambit)
                .WithMany(x => x.AmbitsToTypes)
                .HasForeignKey(x => x.AmbitId);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.AmbitsToTypes)
                .HasForeignKey(x => x.TypeId);
        }
    }
}
