using Dima.Core.Handlers;
using Dima.Web;
using Dima.Web.Handler;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Configuration.BackEndUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? String.Empty;




builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(Configuration.HttpClientName, opt =>
    {
        opt.BaseAddress = new Uri(Configuration.BackEndUrl);
    }).AddHttpMessageHandler<CookieHandler>()
    ;
builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransationHandler, TransationHandler>();

await builder.Build().RunAsync();
