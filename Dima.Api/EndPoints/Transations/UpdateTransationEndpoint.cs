﻿using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.EndPoints.Transations;

public class UpdateTransationEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Transations: Update")
            .WithSummary("Actualizar uma Transation")
            .WithDescription("Actualizar uma Transation")
            .WithOrder(2)
            .Produces<Response<Transation?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransationHandler handler,
        UpdateTransationRequest request,
        long id)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}