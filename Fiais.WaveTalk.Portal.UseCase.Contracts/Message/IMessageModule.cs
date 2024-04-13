using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message;

public interface IMessageModule
{
    IGetMessageByChatRoom GetMessageByChatRoom { get; }
}