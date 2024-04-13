using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.ChatRoom;

internal sealed class GetChatRooms : IGetChatRooms
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IMapper _mapper;
    
    public GetChatRooms(IRepositoryModule repositoryModule, IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _mapper = mapper;
    }
    
    public async Task<ICollection<GetChatRoomsDto>> Execute()
    {
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetAll();

        return _mapper.Map<ICollection<GetChatRoomsDto>>(chatRooms);
    }
}