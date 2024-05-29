using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.EnterChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.User;

public sealed class EnterChatRoom : IEnterChatRoom
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;

    public EnterChatRoom(IRepositoryModule repositoryModule, IUserContext userContext)
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
    }

    public async Task<bool> Execute(EnterChatRoomRequest request)
    {
        request.Format();

        var userId = _userContext.Id ?? Guid.Empty;
        var user = await _repositoryModule.UserRepository.GetById(userId)
            ?? throw new ApplicationUserNotFoundException();

        var chatRoom = await _repositoryModule.ChatRoomRepository.GetById(request.ChatRoomId)
            ?? throw new ApplicationNotFoundException("ChatRoom");

        if (chatRoom.IsPrivate)
        {
            var authorize = chatRoom.Password == request.Password;
            if (!authorize) throw new ApplicationChatRoomPasswordInvalidException();
        }

        user.ChatRooms ??= [];
        if (user.ChatRooms.All(x => x.Id != request.ChatRoomId))
        {
            user.ChatRooms.Add(chatRoom);
            await _repositoryModule.UserRepository.Update(user);
        }

        return true;
    }
}
