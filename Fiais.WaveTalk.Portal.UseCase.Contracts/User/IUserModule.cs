using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User;

public interface IUserModule
{
    IAuthenticate Authenticate { get; }
}