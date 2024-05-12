using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Hub.Models;

namespace Fiais.WaveTalk.Portal.CrossCutting.Mapper;

public static class MessageConfig
{
    public static void Configure(this IMapperConfigurationExpression config)
    {
        config.CreateMap<Message, MessageResponse>()
            .ForMember(x => x.Username, x => x.MapFrom(y => y.User!.Username));
    }
}

