using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext context):ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category,201,"Categoria Criada com Sucesso!");

        }
        catch
        {
            //Todo: Serilog
         return   new Response<Category?>(null, 500, "Nao foi possivel criar a Categoria");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id
                    && x.UserId == request.UserId);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria nao Encontrada");
            category.Title = request.Title;
            category.Description = request.Description;
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category,message:"Categoria actualizada com Sucesso!");
        }
        catch 
        {
            //Usar a estrategia  de codificar o erro como [FP079]-para facilitar a identificacao e localizaco do mesmo
            return   new Response<Category?>(null, 500, "Nao foi possivel alterar a Categoria");
        }
        
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id
                    && x.UserId == request.UserId);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria nao Encontrada");
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category,message:"Categoria removida com Sucesso!");
        }
        catch 
        {
            //Usar a estrategia  de codificar o erro como [FP079]-para facilitar a identificacao e localizaco do mesmo
            return   new Response<Category?>(null, 500, "Nao foi possivel excluir a Categoria");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            return category is null
                ? new Response<Category?>(category, message: "Categoria nao encontrada!")
                : new Response<Category?>(category);
        }
        catch 
        {
            //Usar a estrategia  de codificar o erro como [FP079]-para facilitar a identificacao e localizaco do mesmo
            return   new Response<Category?>(null, 500, "Nao foi possivel recuperar a Categoria");
        }
    }

    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {try
        {

            var query = context
                .Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x=>x.Title);

            var categories = await query
                .Skip((request.PagedNumber-1) * request.PagedNumber)
                .Take(request.PageSize)
                .ToListAsync();
            var totalCount = await query.CountAsync();
            return new PagedResponse<List<Category>>(categories, totalCount, request.PagedNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Category>>(null, 500, "Nao foi possivel consultar as categorias");
        }

    }
}