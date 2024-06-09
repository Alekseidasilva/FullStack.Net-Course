namespace Dima.Core.Request.Transations;

public class GetTransationByPeriodRequest:PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}