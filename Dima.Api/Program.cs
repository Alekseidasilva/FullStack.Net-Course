using Dima.Api.Data;
using Dima.Core.Enums;
using Dima.Core.Models;
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
        "/v1/categories",
        (Request request, Handler handler)
            => handler.Handle(request))
    .WithName("Categories : Create")
    .WithSummary("Cria uma nova Categoria")
    .Produces<Response>();




app.Run();

//Request
public class Request()
{
 
    public string Title { get; set; }=String.Empty;
    public string Description { get; set; }=String.Empty;
}
//Response
public class Response()
{
    public long Id { get; set; }
    public string Title { get; set; }
    
}
//Hanbler
public class Handler(AppDbContext context)
{
    public Response Handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description
        };
        context.Categories.Add(category);
        context.SaveChanges();
        return new Response
        {
          Id =category.Id,
          Title = category.Title
        };
    }
}

