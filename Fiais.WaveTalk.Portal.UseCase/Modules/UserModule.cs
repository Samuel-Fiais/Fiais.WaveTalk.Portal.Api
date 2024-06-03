using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Cases.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.EnterChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;
using Microsoft.Extensions.Configuration;

namespace Fiais.WaveTalk.Portal.UseCase.Modules;

public sealed class UserModule : IUserModule
{
    public UserModule(
        IRepositoryModule module,
        IUserContext userContext,
        IConfiguration configuration
    )
    {
        Authenticate = new Authenticate(module, configuration);
        Create = new Create(module);
        EnterChatRoom = new EnterChatRoom(module, userContext);
    }

    public IAuthenticate Authenticate { get; }
    public ICreate Create { get; }
    public IEnterChatRoom EnterChatRoom { get; }
}