using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class Create : ICreate
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public Create(
        IRepositoryModule repositoryModule,
        IUserContext userContext,
        IMapper mapper
    )
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<bool> Execute(CreateRequestChatRoom request)
    {
        request.Format();
        var userId = _userContext.Id ?? Guid.Empty;
        var user = await _repositoryModule.UserRepository.GetByIdWithChatRooms(userId)
            ?? throw new ApplicationUserNotFoundException();

        var chatRoom = _mapper.Map<Domain.Entity.ChatRoom>(request);

        chatRoom.OwnerId = userId;

        var chatRoomCreated = await _repositoryModule.ChatRoomRepository.Create(chatRoom);

        user.ChatRooms ??= [];
        user.ChatRooms.Add(chatRoomCreated);

        await _repositoryModule.UserRepository.Update(user);

        return true;
    }
}
