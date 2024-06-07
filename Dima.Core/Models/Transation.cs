using Dima.Core.Enums;

namespace Dima.Core.Models;

public class Transation
{
    public long Id { get; set; }
    public string Title { get; set; }=String.Empty;
    
    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public DateTime? PaidOrReceivedAt { get; set; } = null;

    public ETransationType Type { get; set; } = ETransationType.Withdraw;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string UserId { get; set; }=String.Empty;
}