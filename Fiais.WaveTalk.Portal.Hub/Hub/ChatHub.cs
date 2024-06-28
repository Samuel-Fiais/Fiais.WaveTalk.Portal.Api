using Microsoft.AspNetCore.SignalR;

using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Hub.Models;
using Fiais.WaveTalk.Portal.Hub.Shared;

namespace Fiais.WaveTalk.Portal.Hub.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly ConnectionSingleton _connectionSingleton;
    private static ICollection<User> _users = [];

    public ChatHub(
        IRepositoryModule repositoryModule,
        ConnectionSingleton connectionSingleton
    )
    {
        _repositoryModule = repositoryModule;
        _connectionSingleton = connectionSingleton;
    }

    public async Task JoinChat(Guid userId)
    {
        if (userId == Guid.Empty) return;

        var user = await _repositoryModule.UserRepository.GetById(userId);

        if (user is null) return;

        var connectionExists = _connectionSingleton.Connections.Values.Any(x => x?.UserId == userId);

        if (connectionExists) _connectionSingleton.RemoveConnectionByUserId(userId);

        _connectionSingleton.Connections[Context.ConnectionId] = new UserConnection()
        {
            UserId = userId,
            Username = user.Username,
            Name = user.Name,
            Email = user.Email
        };

        var groups = await _repositoryModule.ChatRoomRepository.GetByUser(userId);
        foreach (var group in groups)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group.Id.ToString());
        }
    }

    public async Task SendMessage(string message, Guid chatRoomId)
    {
        if (string.IsNullOrEmpty(message)) return;

        if (_connectionSingleton.Connections.TryGetValue(Context.ConnectionId, out UserConnection? conn))
        {
            if (conn is not null)
            {
                var messageEntity = new Message(
                    message,
                    conn.UserId,
                    chatRoomId
                );

                var messageCreated = await _repositoryModule.MessageRepository.Create(messageEntity);
                var user = _users.FirstOrDefault(x => x.Id == messageCreated.UserId);

                await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", new MessageResponse(
                    messageCreated.Id,
                    messageCreated.AlternateId,
                    messageCreated.ChatRoomId,
                    messageCreated.UserId,
                    user?.Username ?? "Usuário desconhecido",
                    messageCreated.Content,
                    messageCreated.CreatedAt
                ));

                var chatRoom = await _repositoryModule.ChatRoomRepository.GetById(chatRoomId);

                var messageContent = messageCreated.Content.Length > 50
                    ? messageCreated.Content[..50] + "..."
                    : messageCreated.Content;

                await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveNotification", new NotificationResponse()
                {
                    ChatRoomId = chatRoomId,
                    UserId = user?.Id ?? Guid.Empty,
                    Message = $"{user?.Name} escreveu: \"{messageContent}\" em {chatRoom?.Description}"
                });
            }
        }
    }

    public async Task RefreshChatRooms()
    {
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetAll();

        foreach (var chatRoom in chatRooms)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoom.Id.ToString());
        }
    }
}