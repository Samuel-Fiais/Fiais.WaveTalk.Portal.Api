using System.Net;
using Fiais.WaveTalk.Portal.Application.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Middlewares;

public sealed class ApiResult : IActionResult
{
    private readonly ResponseApi _response;

    public ApiResult(object? data, string? message = null)
    {
        _response = new ResponseApi(true, message, data);
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_response)
        {
            StatusCode = context.HttpContext.Request.Method == "POST"
                ? (int)HttpStatusCode.Created
                : (int)HttpStatusCode.OK
        };

        await objectResult.ExecuteResultAsync(context);
    }
}
