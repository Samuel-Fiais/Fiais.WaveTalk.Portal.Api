using Fiais.WaveTalk.Portal.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiais.WaveTalk.Portal.Infra.Data.Configurations;

internal sealed class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Username)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.HasMany(x => x.ChatRooms)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "ChatRoomUser",
                x => x.HasOne<ChatRoom>().WithMany().HasForeignKey("ChatRoomId").OnDelete(DeleteBehavior.NoAction),
                x => x.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction)
            );

        builder.HasMany(x => x.Messages)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.OwnedChatRooms)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}