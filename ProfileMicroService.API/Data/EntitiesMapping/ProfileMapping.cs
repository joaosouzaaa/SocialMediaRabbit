using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileMicroService.API.Entities;

namespace ProfileMicroService.API.Data.EntitiesMapping;

public sealed class ProfileMapping : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Username)
            .HasColumnName("username")
            .HasColumnType("varchar(50)")
            .IsRequired(true);

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(100)")
            .IsRequired(true);

        builder.Property(p => p.CreationDate)
            .HasColumnName("creation_date")
            .HasColumnType("datetime2")
            .IsRequired(true);
    }
}
