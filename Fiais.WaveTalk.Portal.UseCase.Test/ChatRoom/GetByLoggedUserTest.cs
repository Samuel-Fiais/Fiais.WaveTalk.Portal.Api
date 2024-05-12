using Fiais.WaveTalk.Portal.CrossCutting.Mapper;
using Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;
using Xunit;

namespace Fiais.WaveTalk.Portal.UseCase.Test.ChatRoom;

public class GetByLoggedUserTest
{
    private readonly IGetByLoggedUser _useCase;

    public GetByLoggedUserTest()
    {
        var mapperMock = MapperConfig.GetMapperConfiguration().CreateMapper();
        _useCase = new GetByLoggedUser(new RepositoryModuleMock(), new UserContextMock(), mapperMock);
    }

    [Fact]
    public async Task Execute_WhenCalled_ShouldReturnChatRooms()
    {
        // Arrange
        var expectedChatRooms = new List<GetByLoggedUserResponse>
        {
            new()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                AlternateId = "00002",
                CreatedAt = new DateTime(2021, 1, 2),
                IsPrivate = true,
                Description = "Chat Room 2",
                OwnerUsername = "User1",
                OwnerName = "User 1",
                OwnerEmail = "user1@example.com.br",
                Users = new List<GetByLoggedUserResponse.User>
                {
                    new()
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000011"),
                        AlternateId = 1,
                        Email = "user1@example.com.br",
                        Name = "User 1",
                        Username = "User1"
                    },
                    new()
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000012"),
                        AlternateId = 2,
                        Email = "user2@example.com.br",
                        Name = "User 2",
                        Username = "User2"
                    }
                }
            },
            new()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                AlternateId = "00001",
                CreatedAt = new DateTime(2021, 1, 1),
                IsPrivate = true,
                Description = "Chat Room 1",
                OwnerUsername = "User1",
                OwnerName = "User 1",
                OwnerEmail = "user1@example.com.br",
                Users = new List<GetByLoggedUserResponse.User>
                {
                    new()
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000011"),
                        AlternateId = 1,
                        Email = "user1@example.com.br",
                        Name = "User 1",
                        Username = "User1"
                    }
                },
            },
        };

        // Act
        var result = await _useCase.Execute();

        // Assert
        Assert.Equal(expectedChatRooms, result);
    }
}