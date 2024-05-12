using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;
using Fiais.WaveTalk.Portal.CrossCutting.Mapper;
using Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;
using Xunit;

namespace Fiais.WaveTalk.Portal.UseCase.Test.ChatRoom;

public class GetChatRoomTest
{
    private readonly IGet _useCase;

    public GetChatRoomTest()
    {
        var mapperMock = MapperConfig.GetMapperConfiguration().CreateMapper();
        _useCase = new Get(new RepositoryModuleMock(), mapperMock);
    }

    [Fact]
    public async Task Execute_WhenCalled_ShouldReturnChatRooms()
    {
        // Arrange
        var expectedChatRooms = new List<GetResponse>
        {
            new()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedAt = new DateTime(2021, 1, 1),
                Description = "Chat Room 1",
                OwnerId = new Guid("00000000-0000-0000-0000-000000000011"),
                IsPrivate = true
            },
            new()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                CreatedAt = new DateTime(2021, 1, 2),
                Description = "Chat Room 2",
                OwnerId = new Guid("00000000-0000-0000-0000-000000000011"),
                IsPrivate = true
            },
            new()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                CreatedAt = new DateTime(2021, 1, 3),
                Description = "Chat Room 3",
                OwnerId = new Guid("00000000-0000-0000-0000-000000000012"),
                IsPrivate = false
            }
        };

        // Act
        var result = await _useCase.Execute();

        // Assert
        Assert.Equal(expectedChatRooms, result);
    }
}