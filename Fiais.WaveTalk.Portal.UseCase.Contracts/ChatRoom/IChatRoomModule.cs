using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;

public interface IChatRoomModule
{
    IGet Get { get; }
    IGetByLoggedUser GetByLoggedUser { get; }
    IGetByCode GetByCode { get; }
    ICreate Create { get; }
}