using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.Common.EndPoints.Transations;

public class DeleteTransationEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Transations: Delete")
            .WithSummary("Excluir uma Transacao")
            .WithDescription("Excluir uma Transacao")
            .WithOrder(3)
            .Produces<Response<Transation?>>();

    private static async Task<IResult> HandleAsync(
        ITransationHandler handler,
        long id)
    {
        var request = new DeleteTransationRequest()
        {
            UserId = "test@test.ao",
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}