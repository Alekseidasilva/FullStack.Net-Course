var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Endpoints->Url para Acesso
app.MapGet("/", () => "Hello World!");


app.Run();
