using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.CrossCutting.Mapper;
using Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;
using Xunit;

namespace Fiais.WaveTalk.Portal.UseCase.Test.ChatRoom;

public class GetByCodeChatRoomTest
{
    private readonly IGetByCode _useCase;
    
    public GetByCodeChatRoomTest()
    {
        var mapperMock = MapperConfig.GetMapperConfiguration().CreateMapper();
        _useCase = new GetByCode(new RepositoryModuleMock(), mapperMock);
    }
    
    [Theory]
    [InlineData("001")]
    [InlineData("2")]
    [InlineData("00003")]
    public async Task Execute_WhenCalled_ShouldReturnChatRoom(string code)
    {
        // Arrange
        var expectedChatRoom = new GetByCodeResponse()
        {
            Id = new Guid($"00000000-0000-0000-0000-00000000000{code}"),
            Description = $"Chat Room {code}",
            OwnerName = code == "3" ? "User 2" : "User 1",
            IsPrivate = code != "3"
        };
        
        // Act
        var result = await _useCase.Execute(code);
        
        // Assert
        Assert.Equal(expectedChatRoom, result);
    }
    
    [Theory]
    [InlineData("a00")]
    [InlineData("")]
    [InlineData("5")]
    public async Task Execute_WhenCalled_ShouldThrowApplicationNotFoundException(string code)
    {
        // Assert
        await Assert.ThrowsAsync<ApplicationNotFoundException>(Act);
        return;

        // Act
        async Task Act() => await _useCase.Execute(code);
    }
}