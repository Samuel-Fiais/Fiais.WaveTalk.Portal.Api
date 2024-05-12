using AutoMapper;

namespace Fiais.WaveTalk.Portal.CrossCutting.Mapper;

public static class MapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        return new MapperConfiguration(config =>
        {
            ChatRoomConfig.Configure(config);
            UserConfig.Configure(config);
            MessageConfig.Configure(config);
        });
    }
}

