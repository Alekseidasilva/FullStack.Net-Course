using Dima.Api.Data;
using Dima.Core.Enums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnString = builder.Configuration.GetConnectionString("DefaultConnection")??string.Empty;

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(cnnString);
});
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=>
{
    x.CustomSchemaIds(n=>n.FullName);//Full Qualifield Name
});
builder.Services.AddTransient<Handler>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//Endpoints->Url para Acesso
app.MapPost(
        "/v1/Transitions",
        (Request request, Handler handler)
            => handler.Handle(request))
    .WithName("Transations : Create")
    .WithSummary("Cria uma nova Transacao")
    .Produces<Response>();




app.Run();

//Request
public class Request()
{
 
    public string Title { get; set; }=String.Empty;
    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public ETransationType Type { get; set; } = ETransationType.Withdraw;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; }=String.Empty;
}
//Response
public class Response()
{
    public long Id { get; set; }
    public string Title { get; set; }
    
}
//Hanbler
public class Handler
{
    public Response Handle(Request request)
    {
        //Faz todo Processo de Criacao
        //Persiste no Banco
        return new Response
        {
          Id = 4,
          Title = request.Title
        };
    }
}

