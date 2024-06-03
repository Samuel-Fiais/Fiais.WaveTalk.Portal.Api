namespace Fiais.WaveTalk.Portal.Hub.Models;

internal class NotificationResponse
{
    public string Message { get; set; } = string.Empty;
    public Guid ChatRoomId { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
}
