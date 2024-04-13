using Fiais.WaveTalk.Portal.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiais.WaveTalk.Portal.Infra.Data.Configurations;

internal sealed class ChatRoomConfiguration : BaseConfiguration<ChatRoom>
{
    public override void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Password);
        
        builder.Property(x => x.IsPrivate)
            .IsRequired();
        
        builder.HasOne(x => x.Owner)
            .WithMany(x => x.OwnedChatRooms)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Users)
            .WithMany(x => x.ChatRooms);
            
        builder.HasMany(x => x.Messages)
            .WithOne(x => x.ChatRoom)
            .HasForeignKey(x => x.ChatRoomId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}