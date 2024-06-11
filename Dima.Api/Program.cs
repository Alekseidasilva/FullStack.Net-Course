using Dima.Api.Common.Api;
using Dima.Api.Common.EndPoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigins();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();
app.UseSecurity();
app.MapEndPoints();
app.Run();


