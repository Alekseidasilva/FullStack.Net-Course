using Dima.Api.Common.Api;
using Dima.Api.Common.EndPoints.Categories;

namespace Dima.Api.Common.EndPoints;

public static class EndPoint
{
    //Extension Methods(Metodo de Extensao)-Permite que a gente sobrescreva metodos do .Net
    public static void MapEndPoints(this WebApplication app)
    {
        //Tudo que fizemos aqui, ira aplicar em todas as rotas 
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
           // .RequireAuthorization()
            .MapEndPoints<CreateCategoryEndPoint>();
    }

    private static IEndpointRouteBuilder MapEndPoints<TEndPoint>(this IEndpointRouteBuilder app)
        where TEndPoint : IEndPoint
    {
        TEndPoint.Map(app);
        return app;
    }
   
    
}