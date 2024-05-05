using System.Diagnostics;
using System.Net;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Application.Helpers;
using Newtonsoft.Json;
using ApplicationException = System.ApplicationException;

namespace Fiais.WaveTalk.Portal.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var response = context.Response;
        var sw = new Stopwatch();

        try
        {
            sw.Start();
            await next(context);
        }
        catch (Exception ex)
        {
            sw.Stop();

            var r = new ResponseApi(false, ex.Message);

            response.ContentType = "application/json";
            response.StatusCode = ex switch
            {
                ApplicationNoContentException => (int)HttpStatusCode.NotFound,
                ApplicationNotFoundException => (int)HttpStatusCode.NotFound,
                ApplicationUnauthorizedException => (int)HttpStatusCode.Unauthorized,
                ApplicationTokenInvalidException => (int)HttpStatusCode.Unauthorized,
                ApplicationTokenExpiredException => (int)HttpStatusCode.Unauthorized,
                ApplicationUserDisabledException => (int)HttpStatusCode.Unauthorized,
                ApplicationInternalServerErrorException => (int)HttpStatusCode.InternalServerError,
                ApplicationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            if (response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                var message = ex.Message + " - " + ex.StackTrace;
                logger.LogError(message);
                // r.Message = message;
            }

            var json = JsonConvert.SerializeObject(r);
            await response.WriteAsync(json);
        }
    }
}