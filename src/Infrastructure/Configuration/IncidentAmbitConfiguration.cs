using Domain.Entities.HelpDesk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class IncidentAmbitConfiguration : IEntityTypeConfiguration<IncidentAmbit>
    {
        public void Configure(EntityTypeBuilder<IncidentAmbit> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(a => a.Origin).WithMany(o => o.Ambits).HasForeignKey(a => a.OriginId);
        }
    }

}
