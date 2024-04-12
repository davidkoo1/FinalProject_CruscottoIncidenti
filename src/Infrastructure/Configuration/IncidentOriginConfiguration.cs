using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.HelpDesk;

namespace Infrastructure.Configuration
{
    public class IncidentOriginConfiguration : IEntityTypeConfiguration<IncidentOrigin>
    {
        public void Configure(EntityTypeBuilder<IncidentOrigin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            
        }
    }
}
