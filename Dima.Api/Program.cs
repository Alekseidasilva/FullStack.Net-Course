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
        "/v1/categories", async (CreateCategoryRequest request, ICategoryHandler handler)
            => await handler.CreateAsync(request))
    .WithName("Categories : Create")
    .WithSummary("Cria uma nova Categoria")
    .Produces<Response<Category?>>();
app.MapPut(
        "/v1/categories/{id}", async (long id,
                UpdateCategoryRequest request, ICategoryHandler handler)
            =>
        {
            request.Id = id;
        await  handler.UpdateAsync(request);
        })
    .WithName("Categories : Update")
    .WithSummary("Actualiza uma nova Categoria")
    .Produces<Response<Category?>>();

app.MapDelete(
        "/v1/categories/{id}", async (long id,
                ICategoryHandler handler)
            =>
        {
            var request = new DeleteCategoryRequest
            {
                Id = id
            };
            return await handler.DeleteAsync(request);
        })
    .WithName("Categories : Delete")
    .WithSummary("exclui uma  Categoria")
    .Produces<Response<Category?>>();
app.MapGet(
        "/v1/categories/{id}", async (long id,
                ICategoryHandler handler)
            =>
        {
            var request = new GetCategoryByIdRequest()
            {
                Id = id
            };
            return await handler.GetByIdAsync(request);
        })
    .WithName("Categories : Get By Id")
    .WithSummary("Recuperar uma  Categoria")
    .Produces<Response<Category?>>();
app.Run();

//Validar o Request
//Verificar se a categoria exist 
//Inserir no Banco
//Montar a rerspota
//retornar a respota
