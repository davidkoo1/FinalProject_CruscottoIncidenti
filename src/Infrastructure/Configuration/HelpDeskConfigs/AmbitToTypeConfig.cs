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

            builder.HasData(DbSeed.AmbitsToTypes1, DbSeed.AmbitsToTypes2, DbSeed.AmbitsToTypes3, DbSeed.AmbitsToTypes4, DbSeed.AmbitsToTypes5, DbSeed.AmbitsToTypes6,
                DbSeed.AmbitsToTypes7, DbSeed.AmbitsToTypes8, DbSeed.AmbitsToTypes9, DbSeed.AmbitsToTypes10, DbSeed.AmbitsToTypes11, DbSeed.AmbitsToTypes12, 
                DbSeed.AmbitsToTypes13, DbSeed.AmbitsToTypes14, DbSeed.AmbitsToTypes15, DbSeed.AmbitsToTypes16, DbSeed.AmbitsToTypes17, DbSeed.AmbitsToTypes18,
                DbSeed.AmbitsToTypes19, DbSeed.AmbitsToTypes20,DbSeed.AmbitsToTypes21, DbSeed.AmbitsToTypes22, DbSeed.AmbitsToTypes23, DbSeed.AmbitsToTypes24, 
                DbSeed.AmbitsToTypes25, DbSeed.AmbitsToTypes26, DbSeed.AmbitsToTypes27,DbSeed.AmbitsToTypes28, DbSeed.AmbitsToTypes29, DbSeed.AmbitsToTypes30, 
                DbSeed.AmbitsToTypes31, DbSeed.AmbitsToTypes32, DbSeed.AmbitsToTypes33, DbSeed.AmbitsToTypes34,DbSeed.AmbitsToTypes35, DbSeed.AmbitsToTypes36,
                DbSeed.AmbitsToTypes37, DbSeed.AmbitsToTypes38, DbSeed.AmbitsToTypes39, DbSeed.AmbitsToTypes40, DbSeed.AmbitsToTypes41,
                DbSeed.AmbitsToTypes42, DbSeed.AmbitsToTypes43, DbSeed.AmbitsToTypes44, DbSeed.AmbitsToTypes45, DbSeed.AmbitsToTypes46);
        }
    }
}
