using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class Get : IGet
{
    private readonly IRepositoryModule _repositoryModule;

    public Get(IRepositoryModule repositoryModule)
    {
        _repositoryModule = repositoryModule;
    }

    public async Task<ICollection<GetResponse>> Execute()
    {
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetAll();

        return new List<GetResponse>
        (
            chatRooms.Select
            (
                chatRoom => new GetResponse
                (
                    chatRoom.Id,
                    chatRoom.CreatedAt,
                    chatRoom.Description,
                    chatRoom.OwnerId,
                    chatRoom.IsPrivate
                )
            )
        );
    }
}