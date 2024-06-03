using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.Message;

public sealed class GetByChatRoom : IGetByChatRoom
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;

    public GetByChatRoom(
        IRepositoryModule repositoryModule,
        IUserContext userContext
    )
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
    }

    public async Task<ICollection<GetByChatRoomResponse>> Execute(Guid id)
    {
        var userId = _userContext.Id;

        if (userId == Guid.Empty || id == Guid.Empty) throw new ApplicationUserNotFoundException();

        var chatRooms = await _repositoryModule.ChatRoomRepository.GetByUser(userId ?? Guid.Empty);

        if (chatRooms.All(x => x.Id != id)) throw new ApplicationUserDontVinculateWithChatRoomException();

        var message = await _repositoryModule.MessageRepository.GetAllByChatRoom(id);

        var response = message.Select(x => new GetByChatRoomResponse(
            x.Id,
            x.AlternateId,
            x.ChatRoomId,
            x.UserId,
            x.User?.Username ?? string.Empty,
            x.Content,
            x.CreatedAt
        ));

        return response.ToList();
    }
}