using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.CrossCutting.Mapper;

public static class UserConfig
{
    public static void Configure(this IMapperConfigurationExpression config)
    {
        config.CreateMap<User, GetByLoggedUserResponse.User>();

        config.CreateMap<CreateRequestUser, User>();
    }
}

