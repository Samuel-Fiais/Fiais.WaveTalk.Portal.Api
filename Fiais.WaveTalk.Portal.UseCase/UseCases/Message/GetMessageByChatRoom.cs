using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.Message;

internal sealed class GetMessageByChatRoom : IGetMessageByChatRoom
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;
    
    public GetMessageByChatRoom(
        IRepositoryModule repositoryModule,
        IUserContext userContext,
        IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
        _mapper = mapper;
    }
    
    public async Task<ICollection<GetMessageByChatRoomDto>> Execute(Guid id)
    {
        var userId = _userContext.Id;
        
        if (userId == Guid.Empty || id == Guid.Empty) throw new ApplicationUserNotFoundException();
        
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetByUser(userId ?? Guid.Empty);
        
        if (chatRooms.All(x => x.Id != id)) throw new ApplicationUserDontVinculateWithChatRoomException();
        
        var message = await _repositoryModule.MessageRepository.GetAllByChatRoom(id);
        
        return _mapper.Map<ICollection<GetMessageByChatRoomDto>>(message);
    }
}