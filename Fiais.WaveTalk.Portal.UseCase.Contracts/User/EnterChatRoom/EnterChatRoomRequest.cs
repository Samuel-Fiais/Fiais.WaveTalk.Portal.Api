using System.ComponentModel.DataAnnotations;
using Fiais.WaveTalk.Portal.Application.Extensions;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts;

public sealed record EnterChatRoomRequest
{
    [Required(ErrorMessage = "Chat room id is required")]
    public Guid ChatRoomId { get; set; }
    public string? Password { get; set; }

    public void Format()
    {
        Password = Password?.Trim().Encrypt();
    }
}
