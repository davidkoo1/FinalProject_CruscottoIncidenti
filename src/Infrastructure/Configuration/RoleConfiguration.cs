using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id)
                .IsClustered(false);

            builder.Property(role => role.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(role => role.Name)
                .IsClustered(true)
                .IsUnique();

            builder.HasData(DbSeed.AdminRole, DbSeed.UserRole, DbSeed.OperatorRole);
        }
    }
}
