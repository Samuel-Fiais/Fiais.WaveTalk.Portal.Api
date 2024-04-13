namespace Fiais.WaveTalk.Portal.Application.Helpers;

public class ResponseApi
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public string? Message { get; set; }

    public ResponseApi(bool success, string? message, object? data = null)
    {
        Success = success;
        Data = data;
        Message = message;
    }
}
