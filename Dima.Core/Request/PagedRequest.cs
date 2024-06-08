namespace Dima.Core.Request;

public class PagedRequest:Request
{
    public int PagedNumber { get; set; } = 1;
    public int PageSize { get; set; } = 25;

}