using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

namespace Fiais.WaveTalk.Portal.CrossCutting.Mapper;

public static class ChatRoomConfig
{
    public static void Configure(IMapperConfigurationExpression config)
    {
        config.CreateMap<ChatRoom, GetResponse>();

        config.CreateMap<ChatRoom, GetByLoggedUserResponse>()
            .ForMember(x => x.OwnerName, x => x.MapFrom(y => y.Owner!.Name))
            .ForMember(x => x.OwnerUsername, x => x.MapFrom(y => y.Owner!.Username))
            .ForMember(x => x.OwnerEmail, x => x.MapFrom(y => y.Owner!.Email))
            .ForMember(x => x.AlternateId, x => x.MapFrom(x => x.AlternateId.ToString().PadLeft(5, '0')));

        config.CreateMap<ChatRoom, GetByCodeResponse>()
            .ForMember(x => x.OwnerName, x => x.MapFrom(y => y.Owner!.Name));

        config.CreateMap<CreateRequestChatRoom, ChatRoom>();


        config.CreateMap<Message, GetByChatRoomResponse>()
            .ForMember(x => x.Username, x => x.MapFrom(y => y.User!.Username));
    }
}

