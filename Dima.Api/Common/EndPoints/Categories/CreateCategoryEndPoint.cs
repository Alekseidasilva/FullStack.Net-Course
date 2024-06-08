using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;

namespace Dima.Api.Common.EndPoints.Categories;

public class CreateCategoryEndPoint:IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        var result = await handler.CreateAsync(request);
        if (result.IsSuccess)
            return Results.Created($"/{result.Data.Id}", result.Data);
        return Results.BadRequest(result.Data);
    }
}