using Domain.Entities.HelpDesk;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.HelpDeskConfigs
{
    public class IncidentAmbitConfig : IEntityTypeConfiguration<IncidentAmbit>
    {
        public void Configure(EntityTypeBuilder<IncidentAmbit> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.HasData(DbSeed.Software, DbSeed.Functionality, DbSeed.Phase, DbSeed.Release, DbSeed.Service, DbSeed.TransmissionChannels,
                DbSeed.CICS, DbSeed.Database, DbSeed.HardwareHost, DbSeed.HardwareOpen, DbSeed.Middleware, DbSeed.Networks, DbSeed.Security, DbSeed.BasicHostSoftware,
                DbSeed.OpenBasicSoftware, DbSeed.ServiceSoftware, DbSeed.Storage);
        }
    }
}
