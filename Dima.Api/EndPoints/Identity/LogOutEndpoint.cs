using Dima.Api.Common.Api;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.EndPoints.Identity;

public class LogOutEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout", HandleAsync)
            .RequireAuthorization()
            //.WithName("Categories: Create")
            //.WithSummary("Cria uma nova Categoria")
            // .WithDescription("Cria uma nova Categoria")
            ;

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }

}










