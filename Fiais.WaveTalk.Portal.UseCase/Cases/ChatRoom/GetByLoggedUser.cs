using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class GetByLoggedUser : IGetByLoggedUser
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public GetByLoggedUser(
        IRepositoryModule repositoryModule,
        IUserContext userContext,
        IMapper mapper
    )
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<ICollection<GetByLoggedUserResponse>> Execute()
    {
        var userId = _userContext.Id;

        if (userId == Guid.Empty || userId == null) throw new ApplicationUserNotFoundException();

        var chatRooms = await _repositoryModule.ChatRoomRepository.GetByUser((Guid)userId);

        chatRooms = [.. chatRooms.OrderByDescending(x => x.AlternateId)];
        return _mapper.Map<ICollection<GetByLoggedUserResponse>>(chatRooms);
    }
}