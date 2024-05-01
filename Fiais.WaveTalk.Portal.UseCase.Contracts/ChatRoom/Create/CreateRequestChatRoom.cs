using Fiais.WaveTalk.Portal.Application.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;

public class CreateRequestChatRoom
{
    [Required(ErrorMessage = "Name is required.")]
    public string Description { get; set; } = string.Empty;
    public string? Password { get; set; }
    public bool IsPrivate { get; private set; }

    public void Format()
    {
        Description = Description.Trim();
        Password = string.IsNullOrEmpty(Password) ? null : Password.Trim();
        IsPrivate = string.IsNullOrEmpty(Password) is false;
    }
}
