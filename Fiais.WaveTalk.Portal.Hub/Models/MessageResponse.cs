namespace Fiais.WaveTalk.Portal.Hub.Models;

public class MessageResponse
{
    public Guid Id { get; set;  } = Guid.Empty;
    public int AlternateId { get; set; }
    public Guid UserId { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}