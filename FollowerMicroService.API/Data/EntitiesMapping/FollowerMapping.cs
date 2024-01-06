using FollowerMicroService.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FollowerMicroService.API.Data.EntitiesMapping;

public sealed class FollowerMapping : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.ToTable(nameof(Follow));

        builder.HasKey(f => f.Id);

        builder.Property(f => f.FollowerId)
            .HasColumnName("follower_id")
            .HasColumnType("int")
            .IsRequired(true);

        builder.Property(f => f.FollowingId)
            .HasColumnName("following_id")
            .HasColumnType("int")
            .IsRequired(true);
    }
}
