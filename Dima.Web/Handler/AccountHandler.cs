using Dima.Core.Handlers;
using Dima.Core.Request.Account;
using Dima.Core.Response;
using System.Net.Http.Json;

namespace Dima.Web.Handler;

public class AccountHandler(IHttpClientFactory hppClientFactory) : IAccountHandler
{
    private readonly HttpClient _client = hppClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        await _client.PostAsJsonAsync("/v1/identity/login", request);
    }

    public async Task<Response<string>> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}