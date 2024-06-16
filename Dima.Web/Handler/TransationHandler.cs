using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Web.Handler;

public class TransationHandler : ITransationHandler
{
    public async Task<Response<Transation?>> CreateAsync(CreateTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request)
    {
        throw new NotImplementedException();
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