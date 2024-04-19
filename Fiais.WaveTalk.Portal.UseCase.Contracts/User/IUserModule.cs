using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User;

public interface IUserModule
{
    IAuthenticate Authenticate { get; }
    ICreate Create { get; }
}