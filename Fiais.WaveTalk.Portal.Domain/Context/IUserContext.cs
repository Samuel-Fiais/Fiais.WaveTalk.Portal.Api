namespace Fiais.WaveTalk.Portal.Domain.Context;

public interface IUserContext
{
    public Guid? Id { get; }
    public string? Name { get; }
    public string? Username { get; }
    public string? Email { get; }
}