using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserModule _userModule;
    
    public UserController(IUserModule userModule)
    {
        _userModule = userModule;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequest model) => new ApiResult(await _userModule.Create.Execute(model)); 
}