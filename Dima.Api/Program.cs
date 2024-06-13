using Dima.Api;
using Dima.Api.Common.Api;
using Dima.Api.EndPoints;
using Dima.Core;

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
app.UseCors(ApiConfiguration.CorsPlicyName);
app.UseSecurity();
app.MapEndPoints();

Console.WriteLine(Configuration.BackEndUrl);
Console.WriteLine(Configuration.FrontEndUrl);
app.Run();


