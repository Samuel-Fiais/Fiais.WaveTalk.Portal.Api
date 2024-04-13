using Fiais.WaveTalk.Portal.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiais.WaveTalk.Portal.Infra.Data.Configurations;

internal sealed class MessageConfiguration : BaseConfiguration<Message>
{
    public override void Configure(EntityTypeBuilder<Message> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Content)
            .IsRequired();
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.ChatRoom)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatRoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}