using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

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

            builder.HasData(DbSeed.Configuration, DbSeed.SoftwareMalfunction, DbSeed.ThirdParts, DbSeed.IncorrectChange, DbSeed.Code, DbSeed.ResourceSaturation,
                DbSeed.InsufficientResources, DbSeed.HardwareMalfunction, DbSeed.Degradation, DbSeed.Block, DbSeed.Accesses, DbSeed.CyberAttacks, DbSeed.Certificates,
                DbSeed.Firewall, DbSeed.IDM, DbSeed.Patching);
        }
    }
}
