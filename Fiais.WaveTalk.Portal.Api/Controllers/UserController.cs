using Microsoft.AspNetCore.Mvc;

using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.UseCase.Contracts;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;
using Microsoft.AspNetCore.Authorization;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserModule _userModule;

    public UserController(IUserModule userModule)
    {
        _userModule = userModule;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestUser request) =>
        new ApiResult(await _userModule.Create.Execute(request));

    [HttpPost("enter-chat-room")]
    public async Task<IActionResult> EnterChatRoom([FromBody] EnterChatRoomRequest request) =>
        new ApiResult(await _userModule.EnterChatRoom.Execute(request));
}