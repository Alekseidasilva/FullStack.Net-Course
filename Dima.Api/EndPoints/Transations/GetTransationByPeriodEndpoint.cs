﻿using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.EndPoints.Transations;

public class GetTransationByPeriodEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Transations: Get Transations By Period")
            .WithSummary("Recuperar Transacoes por Periodo")
            .WithDescription("Recuperar Transacoes por Periodo")
            .WithOrder(5)
            .Produces<PagedResponse<List<Transation>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransationHandler handler,
        [FromQuery] DateTime? starDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pagedNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize

    )
    {
        var request = new GetTransationByPeriodRequest()
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PagedNumber = pagedNumber,
            PageSize = pageSize,
            StartDate = starDate,
            EndDate = endDate
        };
        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}