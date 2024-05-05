using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Hub.Models;
using Fiais.WaveTalk.Portal.Hub.Shared;
using Microsoft.AspNetCore.SignalR;

namespace Fiais.WaveTalk.Portal.Hub.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly ConnectionSingleton _connectionSingleton;
    private readonly IMapper _mapper;
    private static ICollection<User> _users = [];

    public ChatHub(
        IRepositoryModule repositoryModule,
        ConnectionSingleton connectionSingleton,
        IMapper mapper
    )
    {
        _repositoryModule = repositoryModule;
        _connectionSingleton = connectionSingleton;
        _mapper = mapper;
    }

    public override async Task OnConnectedAsync()
    {
        var chatRooms = await _repositoryModule.ChatRoomRepository.GetAll();
        _users = await _repositoryModule.UserRepository.GetAll() ?? [];

        foreach (var chatRoom in chatRooms)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoom.Id.ToString());
        }
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
    }

    public async Task SendMessage(string message, Guid chatRoomId)
    {
        if (string.IsNullOrEmpty(message)) return;

        if (_connectionSingleton.Connections.TryGetValue(Context.ConnectionId, out UserConnection? conn))
        {
            if (conn is not null)
            {
                var messageEntity = new Message()
                {
                    ChatRoomId = chatRoomId,
                    UserId = conn.UserId,
                    Content = message
                };

                var messageCreated = await _repositoryModule.MessageRepository.Create(messageEntity);
                messageCreated.User = _users.FirstOrDefault(x => x.Id == messageCreated.UserId);

                await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", _mapper.Map<MessageResponse>(messageCreated));
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