﻿using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.EndPoints.Transations;

public class GetTransationByIdEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Transations: Get By Id")
            .WithSummary("Recuperar uma Transacao")
            .WithDescription("Recuperar uma Transacao")
            .WithOrder(4)
            .Produces<Response<Transation?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransationHandler handler,
        long id)
    {
        var request = new GetTransationByIdRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}