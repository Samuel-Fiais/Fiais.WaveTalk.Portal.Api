using Fiais.WaveTalk.Portal.Domain.Context;

namespace Fiais.WaveTalk.Portal.UseCase.Test;

public class UserContextMock : IUserContext
{
    public Guid? Id { get; } = new Guid("00000000-0000-0000-0000-000000000011");
    public string? Name { get; } = "User 1";
    public string? Username { get; } = "User1";
    public string? Email { get; } = "user1@example.com.br";
}