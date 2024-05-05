using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

internal sealed class GetByCode : IGetByCode
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IMapper _mapper;

    public GetByCode(IRepositoryModule repositoryModule, IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _mapper = mapper;
    }

    public async Task<GetByCodeResponse> ExecuteAsync(string code)
    {
        if (!int.TryParse(code, out var alternateId)) throw new ApplicationNotFoundException("ChatRoom");

        var chatRoom = await _repositoryModule.ChatRoomRepository.GetByAlternateId(alternateId)
            ?? throw new ApplicationNotFoundException("ChatRoom");

        return _mapper.Map<GetByCodeResponse>(chatRoom);
    }
}
