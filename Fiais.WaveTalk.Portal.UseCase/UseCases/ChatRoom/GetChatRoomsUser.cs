using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRoomsUser;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.ChatRoom;

internal sealed class GetChatRoomsUser : IGetChatRoomsUser
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;

    public GetChatRoomsUser(IRepositoryModule repositoryModule, IUserContext userContext)
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
    }

    public async Task<IEnumerable<GetChatRoomsUserDto>> Execute()
    {
        var userId = _userContext.Id;

        if (userId == Guid.Empty || userId == null)
        {
            throw new ApplicationUserNotFoundException();
        }

        var chatRooms = await _repositoryModule.ChatRoomRepository.GetByUser((Guid)userId);

        return chatRooms.Select(x => new GetChatRoomsUserDto(
            x.Id,
            x.AlternateId.ToString().PadLeft(5, '0'),
            x.CreatedAt,
            x.Description,
            x.Owner?.Username ?? string.Empty,
            x.Owner?.Name ?? string.Empty,
            x.Owner?.Email ?? string.Empty
        ));
    }
}