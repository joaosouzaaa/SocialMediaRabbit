using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.API.Entities;

namespace NotificationMicroservice.API.Data.EntitiesMapping;

public sealed class NotificationMapping : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Message)
            .HasColumnName("message")
            .HasColumnType("varchar(100)")
            .IsRequired(true);

        builder.Property(n => n.NotificationType)
            .HasColumnName("notification_type")
            .IsRequired(true);

        builder.Property(n => n.UserId)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .IsRequired(true);
    }
}
