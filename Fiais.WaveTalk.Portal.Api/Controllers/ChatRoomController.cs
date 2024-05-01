using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("chat-rooms")]
public class ChatRoomController : ControllerBase
{
    private readonly IChatRoomModule _chatRoomModule;

    public ChatRoomController(IChatRoomModule chatRoomModule)
    {
        _chatRoomModule = chatRoomModule;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => new ApiResult(await _chatRoomModule.Get.Execute());
    
    [HttpGet("user-logged")]
    public async Task<IActionResult> GetByLoggedUser() => new ApiResult(await _chatRoomModule.GetByLoggedUser.Execute());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestChatRoom request) => new ApiResult(await _chatRoomModule.Create.Execute(request));
}