using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

internal sealed class Get : IGet
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IMapper _mapper;
    
    public Get(IRepositoryModule repositoryModule, IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _mapper = mapper;
    }
    
    public async Task<ICollection<GetResponse>> Execute()
    {
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetAll();

        return _mapper.Map<ICollection<GetResponse>>(chatRooms);
    }
}