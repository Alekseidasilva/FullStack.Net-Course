using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Api.Handlers;

public class TransationHandler(AppDbContext context) : ITransationHandler
{
    public async Task<Response<Transation?>> CreateAsync(CreateTransationRequest request)
    {
        var transation = new Transation
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.Now,
            Amount = request.Amount,
            PaidOrReceivedAt = request.PaidOrReceivedAt,
            Title = request.Title,
            Type = request.Type
        };
        await context.Transations.AddAsync(transation);
        await context.SaveChangesAsync();
        return new Response<Transation?>(transation, 201, "Transacao criada com Sucesso!");
    }

    public async Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request)
    {
        var transation = await context.Transations.FindAsync(request.Id);
        if (transation == null)
            return new Response<Transation?>(null, 404, "Transacao nao encontrada!");
        transation.Title = request.Title;

    }

    public async Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transation?>> GetByIdAsync(GetTransationByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Transation>>> GetByPeriodAsync(GetTransationByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}