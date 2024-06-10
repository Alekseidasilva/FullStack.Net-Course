using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.Common.EndPoints.Transations;

public class CreateTransationEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Transation: Create")
            .WithSummary("Cria uma nova Transacao")
            .WithDescription("Cria uma nova Transacao")
            .WithOrder(1)
            .Produces<Response<Transation?>>();

    private static async Task<IResult> HandleAsync(
        ITransationHandler handler,
        CreateTransationRequest request)
    {
        request.UserId = "test@test.ao";
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}