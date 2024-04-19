using Fiais.WaveTalk.Portal.Application.Extensions;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;

public sealed record AuthenticateRequest
{
    public string EmailOrUsername { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public void Format()
    {
        EmailOrUsername = EmailOrUsername.Trim().ToLower();
        Password = Password.Trim().Encrypt();
    }
}