using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("messages")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMessageModule _messageModule;

    public MessageController(IMessageModule messageModule)
    {
        _messageModule = messageModule;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByChatRoom(Guid id) =>
        new ApiResult(await _messageModule.GetByChatRoom.Execute(id));
}