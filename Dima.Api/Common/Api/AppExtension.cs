using System.Security.Claims;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnviroment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapSwagger().RequireAuthorization();
    }

    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("/logout", async (
                SignInManager<User> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();

            })
            .RequireAuthorization();
        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("/roles", async (ClaimsPrincipal user
            ) =>
            {

                if (user.Identity is null
                    || !user.Identity.IsAuthenticated)
                    return Results.Unauthorized();

                var identity = (ClaimsIdentity)user.Identity;
                var roles = identity
                    .FindAll(identity.RoleClaimType)
                    .Select(c=>new
                    {
                        c.Issuer,
                        c.OriginalIssuer,
                        c.Type,
                        c.ValueType
                    });
        
                return TypedResults.Json(roles);

            })
            .RequireAuthorization();
    }
}