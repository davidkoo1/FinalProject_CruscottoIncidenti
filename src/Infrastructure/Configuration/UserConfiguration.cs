using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.UserName)
                .HasMaxLength(7)
                .IsRequired();

            builder.HasIndex(user => user.UserName)
                .IsUnique();

            builder.Property(user => user.FullName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.IsEnabled)
                .HasDefaultValue(true);

        }
    }
}
