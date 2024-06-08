namespace Dima.Core.Response;

public class Response
{
    public Response(string? data, string message, int code)
    {
        Data = data;
        Message = message;
        _code = code;
    }
    private readonly int _code;
    public string? Data { get; set; }
    public string Message { get; set; }

    public bool IsSuccess => _code is >= 200 and <= 299;
}