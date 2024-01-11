using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileMicroService.API.Entities;

namespace ProfileMicroService.API.Data.EntitiesMapping;

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

        builder.HasOne(f => f.Follower)
            .WithMany()
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Following)
            .WithMany()
            .HasForeignKey(f => f.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
