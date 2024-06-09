using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Common.EndPoints.Categories;

public class GetAllCategoryEndPoint:IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{pageSize}/{pagedNumber}", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Recuperar todas as Categorias")
            .WithDescription("Recuperar todas as Categorias")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        [FromQuery] int pagedNumber=Configuration.DefaultPageNumber,
        [FromQuery] int pageSize=Configuration.DefaultPageSize
      
      )
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = "test@test.ao",
            PagedNumber = pagedNumber,
            PageSize =pageSize ,
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}