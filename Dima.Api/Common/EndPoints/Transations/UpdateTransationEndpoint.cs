using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.Common.EndPoints.Transations;

public class UpdateTransationEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/{handler}", HandleAsync)
            .WithName("Transations: Update")
            .WithSummary("Actualizar uma Transation")
            .WithDescription("Actualizar uma Transation")
            .WithOrder(2)
            .Produces<Response<Transation?>>();

    private static async Task<IResult> HandleAsync(
        ITransationHandler handler,
        UpdateTransationRequest request,
        long id)
    {
        request.UserId = "test@test.ao";
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}