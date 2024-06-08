using System.Text.Json.Serialization;

namespace Dima.Core.Response;

public class Response<TData>
{
    private const int DefaultStatusCode = 200;
    
    [JsonConstructor]
    public Response()//Construtor ParameterLess ou sem parametros
    => _code = DefaultStatusCode;
    
    public Response(TData? data,int code=DefaultStatusCode, string? message=null )
    {
        Data = data;
        _code = code;
        Message = message;
        
    }
    private readonly int _code;
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}