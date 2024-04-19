using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticateController : ControllerBase
{
    private readonly IUserModule _userModule;
    
    public AuthenticateController(IUserModule userModule)
    {
        _userModule = userModule;
    }
    
    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model) =>
        new ApiResult(await _userModule.Authenticate.Execute(model));
}