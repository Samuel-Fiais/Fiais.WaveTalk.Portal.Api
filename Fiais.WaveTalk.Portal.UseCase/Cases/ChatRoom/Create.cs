using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class Create : ICreate
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;

    public Create(
        IRepositoryModule repositoryModule,
        IUserContext userContext
    )
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
    }

    public async Task<bool> Execute(CreateRequestChatRoom request)
    {
        request.Format();
        var userId = _userContext.Id ?? Guid.Empty;

        if (userId == Guid.Empty) throw new ApplicationUserNotFoundException();

        var user = await _repositoryModule.UserRepository.GetByIdWithChatRooms(userId)
            ?? throw new ApplicationUserNotFoundException();

        var chatRoom = new Domain.Entity.ChatRoom
        (
            request.Description,
            request.IsPrivate,
            request.Password,
            userId
        );

        var chatRoomCreated = await _repositoryModule.ChatRoomRepository.Create(chatRoom);

        user.ChatRooms.Add(chatRoomCreated);

        await _repositoryModule.UserRepository.Update(user);

        return true;
    }
}
