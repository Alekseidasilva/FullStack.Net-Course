using Dima.Api.Common.EndPoints;
using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
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

app.MapGet("/",()=>new {message="OK"});
app.MapEndPoints();
app.Run();


