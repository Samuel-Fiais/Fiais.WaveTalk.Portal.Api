using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;

public sealed class GetByLoggedUser : IGetByLoggedUser
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IUserContext _userContext;

    public GetByLoggedUser(
        IRepositoryModule repositoryModule,
        IUserContext userContext
    )
    {
        _repositoryModule = repositoryModule;
        _userContext = userContext;
    }

    public async Task<ICollection<GetByLoggedUserResponse>> Execute()
    {
        var userId = _userContext.Id ?? Guid.Empty;

        if (userId == Guid.Empty) throw new ApplicationUserNotFoundException();

        var chatRooms = await _repositoryModule.ChatRoomRepository.GetByUser(userId);

        chatRooms = [.. chatRooms.OrderByDescending(x => x.AlternateId)];
        var response = chatRooms.Select(x =>
        {
            var chatRoom = new GetByLoggedUserResponse(
                x.Id,
                x.AlternateId.ToString().PadLeft(4, '0'),
                x.CreatedAt,
                x.IsPrivate,
                x.Description,
                x.Owner?.Username ?? string.Empty,
                x.Owner?.Name ?? string.Empty,
                x.Owner?.Email ?? string.Empty
            );

            foreach (var user in x.Users)
            {
                chatRoom.AddUser(
                    user.Id,
                    user.AlternateId,
                    user.Email,
                    user.Name,
                    user.Username
                );
            }

            return chatRoom;
        });

        return response.ToList();
    }
}