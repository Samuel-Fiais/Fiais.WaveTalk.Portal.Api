using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message;

public interface IMessageModule
{
    IGetByChatRoom GetByChatRoom { get; }
}