using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class GetByCode : IGetByCode
{
    private readonly IRepositoryModule _repositoryModule;

    public GetByCode(IRepositoryModule repositoryModule)
    {
        _repositoryModule = repositoryModule;
    }

    public async Task<GetByCodeResponse> Execute(string code)
    {
        if (!int.TryParse(code, out var alternateId)) throw new ApplicationNotFoundException("ChatRoom");

        var chatRoom = await _repositoryModule.ChatRoomRepository.GetByAlternateId(alternateId)
            ?? throw new ApplicationNotFoundException("ChatRoom");

        return new GetByCodeResponse
        (
            chatRoom.Id,
            chatRoom.Description,
            chatRoom.Owner?.Name ?? string.Empty,
            chatRoom.IsPrivate
        );
    }
}
