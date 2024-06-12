using Dima.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Dima.Web.Security;

public class CookieAuthenticationStateProvider(IHttpClientFactory clientFactory) : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private readonly HttpClient _client = clientFactory.CreateClient(Configuration.HttpClientName);
    private bool IsAuthenticated = false;

    public async Task<bool> CheckAuthenticatedAsync()
    {
        await GetAuthenticationStateAsync();
        return IsAuthenticated;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        //User
        //Roles=>RoleClaim
        throw new NotImplementedException();
    }

    public void NotifyAuthenticationStateChanged()
    => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    private async Task<User?> GetUser()
    {
        try
        {
            return await _client.GetFromJsonAsync<User?>("v1/identity/manage/info");
        }
        catch
        {
            return null;
        }

    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "Admin")
        };
        claims.AddRange(user.Claims.Where(x => x.Key != ClaimTypes.Name && x.Key != ClaimTypes.Email)
            .Select(x => new Claim(x.Key, x.Value)));
        RoleClaim[]? roles;
        try
        {

            roles = await _client.GetFromJsonAsync<RoleClaim[]>("v1/identity/roles");

        }
        catch
        {
            return claims;
        }

        //foreach (var role in roles ?? [])
        //{
        //    if (!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.ValueType))
        //        claims.Add(new Claim(role.Type, role.Value!, role.ValueType, role.Issuer, role.OriginalIssuer));
        //}
        claims.AddRange(from role in roles ?? [] where !string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.ValueType) select new Claim(role.Type, role.Value!, role.ValueType, role.Issuer, role.OriginalIssuer));
        return claims;
    }
}
