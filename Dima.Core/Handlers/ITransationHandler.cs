using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;

namespace Dima.Core.Handlers;

public interface ITransationHandler
{
    Task<Response<Transation?>> CreateAsync(CreateTransationRequest request);
    Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request);
    Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request);
    Task<Response<Transation?>> GetByIdAsync(GetTransationByIdRequest request);
    Task<PagedResponse<List<Transation>>> GetByPeriodAsync(GetTransationByPeriodRequest request);
}