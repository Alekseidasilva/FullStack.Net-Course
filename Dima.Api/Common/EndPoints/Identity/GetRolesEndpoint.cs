using System.Security.Claims;
using Dima.Api.Common.Api;

namespace Dima.Api.Common.EndPoints.Identity;

public class GetRolesEndpoint:IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/roles", Handle)
            .RequireAuthorization()
    //.WithName("Categories: Create")
    //.WithSummary("Cria uma nova Categoria")
    // .WithDescription("Cria uma nova Categoria")
    ;

    private static Task<IResult> Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());

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
        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
}