using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Enums;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
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
builder.Services.AddTransient<ICategoryHandler,CategoryHandler>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//Endpoints->Url para Acesso
app.MapPost(
        "/v1/categories",
        (CreateCategoryRequest request, ICategoryHandler handler)
            => handler.CreateAsync(request))
    .WithName("Categories : Create")
    .WithSummary("Cria uma nova Categoria")
    .Produces<Response<Category>>();




app.Run();

//Validar o Request
//Verificar se a categoria exist 
//Inserir no Banco
//Montar a rerspota
//retornar a respota
